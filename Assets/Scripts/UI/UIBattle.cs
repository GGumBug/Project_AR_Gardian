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
    public Button btnskill_2;
    public Image dieimg;
    public Button diebtn;

    [SerializeField] TMP_Text hp;
    [SerializeField] TMP_Text atk;
    [SerializeField] TMP_Text pd;
    [SerializeField] TMP_Text ad;
    [SerializeField] Image Item1Img;
    [SerializeField] Image Item1Fade;

    [SerializeField] Slider hpPlayer;
    [SerializeField] Slider hpGuardian;
    [SerializeField] TMP_Text battleInfo;
    public SwipeManager swipeManager = null;
    public TestSwipeManager testSwipeManager = null;

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

        if (testSwipeManager == null)
            testSwipeManager = GetComponent<TestSwipeManager>();

        if (testSwipeManager == null)
            testSwipeManager = gameObject.AddComponent<TestSwipeManager>();
       
        dieimg.DOFade(2, 2f);
        
    }

    public void RefreshHP()
    {
        int a = BattleManager.GetInstance().curGuardian;
        hpPlayer.value = GameManager.GetInstance().NewPlayer.hp;
        GuardianBase guardian = GuardianManager.GetInstance().GetGuardianMonoBase();
        hpGuardian.maxValue = guardian.maxHp;
        hpGuardian.value = guardian.hp;
        hp.text = GameManager.GetInstance().NewPlayer.hp.ToString();
        atk.text = GameManager.GetInstance().NewPlayer.atk.ToString();
        pd.text = GameManager.GetInstance().NewPlayer.parryingDelay.ToString();
        ad.text = GameManager.GetInstance().NewPlayer.attackingDelay.ToString();
        SkillCheck();
    }

    public void BattleInfo(string info)
    {
        battleInfo.text = info;
    }
    public void SkillCheck()
    {
        if(GameManager.GetInstance().NewPlayer.skill_1 == true)
        {
            Item1Img.gameObject.SetActive(true);
        }
        else
            Item1Img.gameObject.SetActive(false);
    }
    public void Fade()
    {

    }
}
