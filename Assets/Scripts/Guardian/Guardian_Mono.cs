using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Mono : MonoBehaviour
{
    public GuardianBase guardian;
    Animator guardianAnimator;

    private void Start()
    {
        StartCoroutine("WaitCreateGuardian");
    }

    IEnumerator WaitCreateGuardian()
    {
        guardianAnimator = BattleManager.GetInstance().FindGuardianAnimator();
        
        float curAnimationTime = guardianAnimator.GetCurrentAnimatorStateInfo(0).length; //현재 재생중인 애니메이션 시간 체크

        yield return new WaitForSeconds(curAnimationTime);
        BattleManager.GetInstance().page = Page.page_1;
    }
}
