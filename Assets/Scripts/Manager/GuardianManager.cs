using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GuardianBase[] GuardianList =
    {
        new lamplight_Guardian("등불도깨비", 10, 100, 100, 2f),
        new Darksini_Guardian("어둑시니", 20, 200, 200, 2f),
        new Duaksini_Guardian("두억시니", 40, 300, 300, 1f),
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
            BattleManager.GetInstance().uIBattle.RefreshHP();
            BattleManager.GetInstance().uIBattle.BattleInfo("Stage Clear");
            GuardianList[curGuardian].isClear = true;
            BattleManager.GetInstance().page = Page.page_0;
            GuardianManager.GetInstance().GuardianList[curGuardian].canAttack = false;
            Object rewardObejct = Resources.Load($"UI/UIReward");
            GameObject itemGameObejct = (GameObject)Instantiate(rewardObejct);
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

}
