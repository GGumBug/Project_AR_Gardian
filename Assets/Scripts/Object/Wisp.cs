using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wisp : MonoBehaviour
{
    UIBattle uIBattle;

    public void OnMouseDown()
    {
        ObjectManager.GetInstance().CreateGuardian(BattleManager.GetInstance().curGuardian);
        GuardianManager.GetInstance().SetGuardian();

        UIManager.GetInstance().OpenUI("UIBattle");
        GameObject uIBattleGo = UIManager.GetInstance().GetUI("UIBattle");
        uIBattle = uIBattleGo.GetComponent<UIBattle>();
        uIBattle.btnAttack.onClick.AddListener(()=> { BattleManager.GetInstance().PlayerAttack(); });
        uIBattle.btnParrying.onClick.AddListener(() => { GameManager.GetInstance().Parrying(); });
        uIBattle.RefreshHP();

        BattleManager.GetInstance().page = Page.page_1;
        Destroy(gameObject);
    }
}
