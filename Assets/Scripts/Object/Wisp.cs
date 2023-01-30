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
        uIBattle.RefreshHP();

        Destroy(gameObject);
    }
}
