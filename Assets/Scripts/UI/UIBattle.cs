using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : MonoBehaviour
{
    public Button btnAttack;
    public Button btnParrying;
    public Slider hpPlayer;
    public Slider hpGuardian;


    public void RefreshHP()
    {
        int a = BattleManager.GetInstance().curGuardian;
        hpPlayer.value = GameManager.GetInstance().NewPlayer.hp;
        hpGuardian.value = GuardianManager.GetInstance().GuardianList[a].hp;
    }
}
