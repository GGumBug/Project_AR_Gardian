using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class UIBattle : MonoBehaviour
{
    [Header ("UI")]
    public Button btnAttack;
    public Button btnTop;
    public Button btnRight;
    public Button btnBottom;
    public Button btnLeft;
    public Button btnskill_1;
    public Image dieimg;
    public Button diebtn;



    [SerializeField] Slider hpPlayer;
    [SerializeField] Slider hpGuardian;
    [SerializeField] TMP_Text battleInfo;
    public SwipeManager swipeManager = null;
    public TestSwipeManager testSwipeManager = null;

    private void Start()
    {
        if(GameManager.GetInstance().NewPlayer.skill_1 == true)
        {
            btnskill_1.gameObject.SetActive(true);
        }
        btnTop.onClick.AddListener(() => { GameManager.GetInstance().Parrying(0); });
        btnRight.onClick.AddListener(() => { GameManager.GetInstance().Parrying(1); });
        btnBottom.onClick.AddListener(() => { GameManager.GetInstance().Parrying(2); });
        btnLeft.onClick.AddListener(() => { GameManager.GetInstance().Parrying(3); });
        btnskill_1.onClick.AddListener(() => { GameManager.GetInstance().SkillBtnClick(btnskill_1); });
        diebtn.onClick.AddListener(() => { GameManager.GetInstance().ReTitle(); });

        if (swipeManager == null)
            swipeManager = GetComponent<SwipeManager>();

        if (swipeManager == null)
            swipeManager = gameObject.AddComponent<SwipeManager>();

        if (testSwipeManager == null)
            testSwipeManager = GetComponent<TestSwipeManager>();

        if (testSwipeManager == null)
            testSwipeManager = gameObject.AddComponent<TestSwipeManager>();
        dieimg.DOFade(1f, 2f);
    }

    public void RefreshHP()
    {
        int a = BattleManager.GetInstance().curGuardian;
        hpPlayer.value = GameManager.GetInstance().NewPlayer.hp;
        GuardianBase guardian = GuardianManager.GetInstance().GetGuardianMonoBase();
        hpGuardian.maxValue = guardian.maxHp;
        hpGuardian.value = guardian.hp;
    }

    public void BattleInfo(string info)
    {
        battleInfo.text = info;
    }
}
