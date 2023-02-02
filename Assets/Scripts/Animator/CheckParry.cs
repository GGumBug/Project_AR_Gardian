using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckParry : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int a = BattleManager.GetInstance().curGuardian;

        BattleManager.GetInstance().page = Page.page_1;
        GuardianManager.GetInstance().GuardianList[a].canAttack = false;
    }
}
