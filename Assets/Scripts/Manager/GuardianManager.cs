using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardianManager : MonoBehaviour
{
    #region Singletone

    private static GuardianManager instance = null;

    public static GuardianManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GuardianManager");
            instance = go.AddComponent<GuardianManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public int attackDirection;

    public bool useUnblockableAttack;


    public GuardianBase[] GuardianList =
    {
        new lamplight_Guardian("등불도깨비", 10, 100, 100, 2f,0),
        new Darksini_Guardian("어둑시니", 20, 200, 200, 2f,20),
        new Duaksini_Guardian("두억시니", 40, 300, 300, 1f,40),
    };

    public Dictionary<string, GameObject> GuardianMonoList = new Dictionary<string, GameObject>();

    public void SetGuardian()
    {
        int curGuardian = BattleManager.GetInstance().curGuardian;
        var guardian = ObjectManager.GetInstance().GetGuardian($"Guardian_{curGuardian}");
        Guardian_Mono guardian_Mono = guardian.GetComponent<Guardian_Mono>();
        guardian_Mono.guardian = GuardianList[curGuardian].Clone();

        GuardianMonoList.Add($"Guardian_{curGuardian}", guardian);
    }

    public GameObject GetGuardianMono()
    {
        int curGuardian = BattleManager.GetInstance().curGuardian;
        if (GuardianMonoList.ContainsKey($"Guardian_{curGuardian}"))
        {
            return GuardianMonoList[$"Guardian_{curGuardian}"];
        }

        return null;
    }

    public GuardianBase GetGuardianMonoBase()
    {
        GameObject go = GetGuardianMono();
        var guardian_Mono = go.GetComponent<Guardian_Mono>();
        GuardianBase guardian = guardian_Mono.guardian;

        return guardian;
    }

    public void GuardianDie()
    {
        GuardianBase guardian = GetGuardianMonoBase();
        int curGuardian = BattleManager.GetInstance().curGuardian;

        if (guardian.hp <= 0)
        {
            guardian.hp = 0;
            Animator animator = GuardianMonoList[$"Guardian_{curGuardian}"].GetComponentInChildren<Animator>();
            animator.SetTrigger("G_Death");
            SwichGuardianDieSound();
            BattleManager.GetInstance().uIBattle.RefreshHP();
            BattleManager.GetInstance().uIBattle.BattleInfo("도깨비 사냥에\n성공했습니다.");
            BattleManager.GetInstance().uIBattle.GameClearImg();
            GuardianList[curGuardian].isClear = true;
            BattleManager.GetInstance().page = Page.page_0;
            GetInstance().GuardianList[curGuardian].canAttack = false;
            GameClear();
        }
    }
    public bool IsOpenGardian(int idx)
    {
        return GuardianList[idx].isClear;
    }

    public void ResetGuardian()
    {
        for (int i = 0; i < GuardianList.Length ; i++)
        {
            GuardianList[i].isClear = false;
        }
        GuardianMonoList.Clear();
    }
    public void GameClear()
    {
        if(GuardianList[0].isClear && GuardianList[1].isClear && GuardianList[2].isClear)
        {
            ScenesManager.GetInstance().EndingSceneChangeInvoke();
            BattleManager.GetInstance().uIBattle.GameClearImg();
        }
        else
        {
            Object rewardObejct = Resources.Load($"UI/UIReward");
            GameObject itemGameObejct = (GameObject)Instantiate(rewardObejct);
        }
    }

    public void UnblockableAttackDamege()
    {
        if (!useUnblockableAttack)
        {
            StopCoroutine("UnblockableAttackDamegeDelay");
            StartCoroutine("UnblockableAttackDamegeDelay");
            useUnblockableAttack = true;
        }
    }

    IEnumerator UnblockableAttackDamegeDelay()
    {
        int a = BattleManager.GetInstance().curGuardian;

        Animator animator = BattleManager.GetInstance().FindGuardianAnimator();
        GuardianList[a].canAttack = false;
        GameManager.GetInstance().NewPlayer.skill_1 = false;

        UIBattle uIBattle = BattleManager.GetInstance().FindUIBattle();

        GameManager.GetInstance().NewPlayer.canAttack = true;
        animator.SetTrigger("G_unblockableAttack");
        AudioManager.instance.GuardianSFXPlay(17);
        if(GameManager.GetInstance().NewPlayer.defence == true)
        {
            GameManager.GetInstance().NewPlayer.defence = false;
            yield return new WaitForSeconds(3f);
            GameManager.GetInstance().NewPlayer.canAttack = true;
            yield return new WaitForSeconds(2f);
            uIBattle.RefreshHP();
            AudioManager.instance.GuardianSFXPlay(27);
            AudioManager.instance.GuardianSFXPlay(28);
            Transform player = GameObject.FindGameObjectWithTag("MainCamera").transform;
            Object obj = Resources.Load("Particle/UseItem");
            GameObject particle = (GameObject)Instantiate(obj, player);
            yield return new WaitForSeconds(2f);
            GameManager.GetInstance().NewPlayer.canAttack = false;
            BattleManager.GetInstance().page = Page.page_1;
            yield break;
        }
        yield return new WaitForSeconds(1f);
        AudioManager.instance.GuardianSFXPlay(27);
        yield return new WaitForSeconds(4f);
        GameManager.GetInstance().SetHp(-100);

        uIBattle.RefreshHP();
        GameManager.GetInstance().PlayerDie();

        yield return new WaitForSeconds(2f);

        BattleManager.GetInstance().page = Page.page_1;
    }

    void SwichGuardianDieSound()
    {
        switch (BattleManager.GetInstance().curGuardian)
        {
            case 0:
                AudioManager.instance.GuardianSFXPlay(4);
                break;
            case 1:
                AudioManager.instance.GuardianSFXPlay(8);
                break;
            case 2:
                AudioManager.instance.GuardianSFXPlay(14);
                break;
        }
    }
}
