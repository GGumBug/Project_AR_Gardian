using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class UIBattle : MonoBehaviour
{
    [Header ("UI")]
    public Button btnTop;
    public Button btnRight;
    public Button btnBottom;
    public Button btnLeft;
    public Image dieimg;
    public Button diebtn;

    [SerializeField] TMP_Text hp;
    [SerializeField] TMP_Text atk;
    [SerializeField] TMP_Text pd;
    [SerializeField] TMP_Text ad;
    [SerializeField] Image Item1Img;
    [SerializeField] Image Item2Img;
    [SerializeField] Image DefenceImg;

    [SerializeField] Slider hpPlayer;
    [SerializeField] TMP_Text battleInfo;
    public SwipeManager swipeManager = null;
    //public TestSwipeManager testSwipeManager = null;

    // 도깨비 사냥에 성공했습니다.
    public Image vicImg1;
    public Image vicImg2;

    private void Start()
    {
        btnTop.onClick.AddListener(() => { GameManager.GetInstance().Parrying(0); });
        btnRight.onClick.AddListener(() => { GameManager.GetInstance().Parrying(1); });
        btnBottom.onClick.AddListener(() => { GameManager.GetInstance().Parrying(2); });
        btnLeft.onClick.AddListener(() => { GameManager.GetInstance().Parrying(3); });
        diebtn.onClick.AddListener(() => { GameManager.GetInstance().ReTitle(); });

        if (swipeManager == null)
            swipeManager = GetComponent<SwipeManager>();

        if (swipeManager == null)
            swipeManager = gameObject.AddComponent<SwipeManager>();

        //if (testSwipeManager == null)
        //    testSwipeManager = GetComponent<TestSwipeManager>();

        //if (testSwipeManager == null)
        //    testSwipeManager = gameObject.AddComponent<TestSwipeManager>();

        dieimg.DOFade(2, 2f);
    }

    public void RefreshHP()
    {
        int a = BattleManager.GetInstance().curGuardian;
        hpPlayer.value = GameManager.GetInstance().NewPlayer.hp;
        GuardianBase guardian = GuardianManager.GetInstance().GetGuardianMonoBase();
        GameObject getguardianmono = GuardianManager.GetInstance().GetGuardianMono();
        UIGuardian getuiguardian = getguardianmono.GetComponentInChildren<UIGuardian>();
        getuiguardian.hpGuardianSlider.maxValue = guardian.maxHp;
        getuiguardian.hpGuardianSlider.value = guardian.hp;
        hp.text = GameManager.GetInstance().NewPlayer.hp.ToString();
        atk.text = GameManager.GetInstance().NewPlayer.atk.ToString();
        pd.text = GameManager.GetInstance().NewPlayer.parryingDelay.ToString();
        ad.text = GameManager.GetInstance().NewPlayer.attackingDelay.ToString();
        Skill1Check();
        Skill2Check();
        SpecialDefenceCheck();
    }

    public void BattleInfo(string info)
    {
        battleInfo.text = info;
    }
    public void Skill1Check()
    {
        if(GameManager.GetInstance().NewPlayer.skill_1 == true)
        {
            Item1Img.gameObject.SetActive(true);
        }
        else
            Item1Img.gameObject.SetActive(false);
    }
    public void Skill2Check()
    {
        if (GameManager.GetInstance().NewPlayer.skill_2 == true)
        {
            Item2Img.gameObject.SetActive(true);
        }
        else
            Item2Img.gameObject.SetActive(false);
    }

    public  void SpecialDefenceCheck()
    {
        if(GameManager.GetInstance().NewPlayer.defence == true)
        {
            DefenceImg.gameObject.SetActive(true);
        }
        else
            DefenceImg.gameObject.SetActive(false);
    }
    public void GameClearImg()
    {
        vicImg1.DOFade(1, 1f);
        vicImg2.DOFade(1, 1f);
    }
}
