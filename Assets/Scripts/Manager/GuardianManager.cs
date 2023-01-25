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

    public GuardianBase[] GuardianList =
    {
        new lamplight_Guardian("등불도깨비", 10, 100, 2f),
        new Darksini_Guardian("어둑시니", 20, 200, 2f),
        new Duaksini_Guardian("두억시니", 40, 300, 1f),
    };

    Dictionary<string, GameObject> GuardianMonoList = new Dictionary<string, GameObject>();

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

    public void GuardianDie()
    {
        int curGuardian = BattleManager.GetInstance().curGuardian;

        if (GuardianList[curGuardian].hp <= 0)
        {
            GuardianList[curGuardian].hp = 0;
            BattleManager.GetInstance().uIBattle.RefreshHP();
            BattleManager.GetInstance().uIBattle.BattleInfo("Stage Clear");
            ScenesManager.GetInstance().EndBattle();
            GuardianList[curGuardian].isClear = true;
            BattleManager.GetInstance().page = Page.page_0;

        }
    }
    public bool IsOpenGardian(int idx)
    {
        return GuardianList[idx].isClear;
    }

}
