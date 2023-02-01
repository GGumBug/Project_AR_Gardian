using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guardian_Mono : MonoBehaviour
{
    bool unblockableAttack;
    public GuardianBase guardian;
    Animator guardianAnimator;
    public UIGuardian uiGuardian;
    private void Start()
    {
        StartCoroutine("WaitCreateGuardian");
    }

    private void Update()
    {
        if (BattleManager.GetInstance().curGuardian == 2 && (float)guardian.hp / guardian.maxHp * 100 <= 50 && !unblockableAttack)
        {
            unblockableAttack = true;
            BattleManager.GetInstance().page = Page.page_2;
        }
    }

    IEnumerator WaitCreateGuardian()
    {
        guardianAnimator = BattleManager.GetInstance().FindGuardianAnimator();
        
        float curAnimationTime = guardianAnimator.GetCurrentAnimatorStateInfo(0).length; //현재 재생중인 애니메이션 시간 체크

        yield return new WaitForSeconds(curAnimationTime);
        BattleManager.GetInstance().page = Page.page_1;
    }
    public void FindGuradianHpbar()
    {
        uiGuardian = gameObject.GetComponentInChildren<UIGuardian>();

    }
}
