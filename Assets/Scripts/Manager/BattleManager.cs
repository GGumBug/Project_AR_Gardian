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

    public Material[] mat = new Material[2];
    Material curmat;

    private void Start()
    {
        mat = Resources.LoadAll<Material>("Material");
    }

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

        GameObject go = GuardianManager.GetInstance().GetGuardianMono();
        MeshRenderer gome = go.GetComponentInChildren<MeshRenderer>();
        curmat = gome.material;
        //공격 애니메이션
        yield return new WaitForSeconds(1.5f);

        GuardianManager.GetInstance().GuardianList[curGuardian].canParrying = true;

        gome.material = mat[1];
        yield return new WaitForSeconds(0.5f);
        GuardianManager.GetInstance().GuardianList[curGuardian].canParrying = false;
        gome.material = curmat;

        GuardianManager.GetInstance().GuardianList[curGuardian].Attack();

        uIBattle = FindUIBattle();
        uIBattle.RefreshHP();
        GameManager.GetInstance().PlayerDie();

        yield return new WaitForSeconds(1f);

        GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = false;
    }

    public IEnumerator PlayerAttackDelay()
    {
        if (GameManager.GetInstance().NewPlayer.canAttack)
        {
            yield break;
        }

        GameManager.GetInstance().NewPlayer.canAttack = true;
        //애니메이션

        yield return new WaitForSeconds(2f);

        GameManager.GetInstance().Attack();

        uIBattle = FindUIBattle();
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
        StopCoroutine("GuardianAttack");

        StartCoroutine("GuardianStunDelay");
    }

    public void ParryingDelay()
    {
        StartCoroutine("ParryingDelayRoutine");
    }

    IEnumerator GuardianStunDelay()
    {
        GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = true;
        // 스턴 애니메이션
        GameObject go = GuardianManager.GetInstance().GetGuardianMono();
        MeshRenderer gome = go.GetComponentInChildren<MeshRenderer>();
        gome.material = mat[0];
        yield return new WaitForSeconds(2f);
        gome.material = curmat;

        GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = false;
        
    }

    IEnumerator ParryingDelayRoutine()
    {
        GameManager.GetInstance().NewPlayer.isParrying = true;
        //패링 애니메이션
        yield return new WaitForSeconds(1f);
        GameManager.GetInstance().NewPlayer.isParrying = false;
    }
}
