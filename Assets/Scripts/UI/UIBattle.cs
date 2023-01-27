using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBattle : MonoBehaviour
{
    [Header ("UI")]
    public Button btnAttack;
    public Button btnTop;
    public Button btnRight;
    public Button btnBottom;
    public Button btnLeft;
    [SerializeField] Slider hpPlayer;
    [SerializeField] Slider hpGuardian;
    [SerializeField] TMP_Text battleInfo;
    [SerializeField] SwipeManager swipeManager = null;
    [SerializeField] TestSwipeManager testSwipeManager = null;

    private void Start()
    {
        //btnAttack.onClick.AddListener(() => { BattleManager.GetInstance().PlayerAttack(); });
        btnTop.onClick.AddListener(() => { GameManager.GetInstance().Parrying(0); });
        btnRight.onClick.AddListener(() => { GameManager.GetInstance().Parrying(1); });
        btnBottom.onClick.AddListener(() => { GameManager.GetInstance().Parrying(2); });
        btnLeft.onClick.AddListener(() => { GameManager.GetInstance().Parrying(3); });

        if (swipeManager == null)
            swipeManager = GetComponent<SwipeManager>();

        if (swipeManager == null)
            swipeManager = gameObject.AddComponent<SwipeManager>();

        if (testSwipeManager == null)
            testSwipeManager = GetComponent<TestSwipeManager>();

        if (testSwipeManager == null)
            testSwipeManager = gameObject.AddComponent<TestSwipeManager>();
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
