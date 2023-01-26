using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBattle : MonoBehaviour
{
    [Header ("UI")]
    public Button btnAttack;
    public Button btnParrying;
    [SerializeField] Slider hpPlayer;
    [SerializeField] Slider hpGuardian;
    [SerializeField] TMP_Text battleInfo;

    private void Start()
    {
        btnAttack.onClick.AddListener(() => { BattleManager.GetInstance().PlayerAttack(); });
        btnParrying.onClick.AddListener(() => { GameManager.GetInstance().Parrying(); });
    }

    public void RefreshHP()
    {
        int a = BattleManager.GetInstance().curGuardian;
        hpPlayer.value = GameManager.GetInstance().NewPlayer.hp;
        hpGuardian.maxValue = GuardianManager.GetInstance().GuardianList[a].maxHp;
        hpGuardian.value = GuardianManager.GetInstance().GuardianList[a].hp;
    }

    public void BattleInfo(string info)
    {
        battleInfo.text = info;

    }
}
