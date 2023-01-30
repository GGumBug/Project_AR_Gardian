using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Page
{
    page_0,
    page_1,
    page_2
}

public class BattleManager : MonoBehaviour
{
    #region SingleTone

    private static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public int curGuardian;//몬스터 순번 0이면 1단계 1이면 2단계 이런식

    public Page page = Page.page_0;

    public UIBattle uIBattle;
    Animator swordAnimator;
    Animator guardianAnimator;

    private void Update()
    {
        if (page == Page.page_1)
        {
            if (!GuardianManager.GetInstance().GuardianList[curGuardian].canAttack)
            {
                GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = true;
                StartCoroutine("GuardianAttack");
            }
        }
        if (page == Page.page_0)
        {
            StopCoroutine("GuardianAttack");
        }
    }

    public void PlayerAttack()
    {
        if (GameManager.GetInstance().NewPlayer.isParrying)
        {
            return;
        }
        StartCoroutine("PlayerAttackDelay");
    }

    IEnumerator GuardianAttack()
    {

        GuardianManager.GetInstance().GuardianList[curGuardian].StartAniMation();
        yield return new WaitForSeconds(1f);

        GuardianManager.GetInstance().GuardianList[curGuardian].canParrying = true;
        Debug.Log(GuardianManager.GetInstance().GuardianList[curGuardian].canParrying);
        yield return new WaitForSeconds(0.5f);
        if (GameManager.GetInstance().NewPlayer.isParrying && GuardianManager.GetInstance().attackDirection == GameManager.GetInstance().parryingDrection)
        {
            GuardianManager.GetInstance().GuardianList[curGuardian].ParryingCheck();
            yield break;
        }
            
        GuardianManager.GetInstance().GuardianList[curGuardian].canParrying = false;
        GuardianManager.GetInstance().GuardianList[curGuardian].Attack();

        uIBattle = FindUIBattle();
        uIBattle.RefreshHP();
        GameManager.GetInstance().PlayerDie();

        yield return new WaitForSeconds(1.5f);

        GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = false;
    }

    public IEnumerator PlayerAttackDelay()
    {
        if (GameManager.GetInstance().NewPlayer.canAttack)
        {
            yield break;
        }

        GameManager.GetInstance().NewPlayer.canAttack = true;
        uIBattle = FindUIBattle();

        switch (uIBattle.testSwipeManager.playerAttackDirection) // 최종 빌드때 SwipManager로 수정
        {
            case 0:
                swordAnimator = FindSwordAnimator();
                swordAnimator.SetTrigger("isAttack_Top");
                break;
            case 1:
                swordAnimator = FindSwordAnimator();
                swordAnimator.SetTrigger("isAttack_Left");
                break;
            case 2:
                swordAnimator = FindSwordAnimator();
                swordAnimator.SetTrigger("isAttack_Bottom");
                break;
            case 3:
                swordAnimator = FindSwordAnimator();
                swordAnimator.SetTrigger("isAttack_Right");
                break;
        }
        swordAnimator = FindSwordAnimator();
        swordAnimator.SetTrigger("isAttack"); // 공격 애니메이션

        yield return new WaitForSeconds(GameManager.GetInstance().NewPlayer.attackingDelay);

        GameManager.GetInstance().Attack();

        uIBattle.RefreshHP();


        GuardianManager.GetInstance().GuardianDie();

        yield return new WaitForSeconds(1f);

        GameManager.GetInstance().NewPlayer.canAttack = false;
    }

    public UIBattle FindUIBattle()
    {
        if (!UIManager.GetInstance().uiList.ContainsKey("UIBattle"))
        {
            Debug.Log("배틀 UI를 찾을수 없습니다.");
        }
        GameObject go = UIManager.GetInstance().GetUI("UIBattle");
        UIBattle uIBattle = go.GetComponent<UIBattle>();

        return uIBattle;
    }

    public void GuardianStun()
    {
        StopCoroutine("GuardianAttack"); // *중복 실행 방지

        StartCoroutine("GuardianStunDelay");
    }

    public void ParryingDelay()
    {
        StopCoroutine("ParryingDelayRoutine");
        StartCoroutine("ParryingDelayRoutine");
    }

    IEnumerator GuardianStunDelay()
    {
        GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = true;
        // 스턴 애니메이션
        FindGuardianAnimator();
        guardianAnimator.SetTrigger("G_Sturn");

        yield return new WaitForSeconds(2f);

        GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = false;

        
    }

    IEnumerator ParryingDelayRoutine()
    {
        swordAnimator = FindSwordAnimator();
        swordAnimator.SetTrigger("isParrying"); //패링 애니메이션
        yield return new WaitForSeconds(GameManager.GetInstance().NewPlayer.parryingDelay);
        GameManager.GetInstance().NewPlayer.isParrying = false;
        GameManager.GetInstance().parryingDrection = -1;
    }

    public Animator FindSwordAnimator()
    {
        GameObject arSessionOrigin = GameObject.FindGameObjectWithTag("ARSessionOrigin");
        Animator swordAnimator = arSessionOrigin.GetComponentInChildren<Animator>();

        return swordAnimator;
    }

    void FindGuardianAnimator()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Guardian");
        guardianAnimator = go.GetComponentInChildren<Animator>();
    }
}
