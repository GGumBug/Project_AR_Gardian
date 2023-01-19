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

    public void SetGuardian()
    {
        int curGuardian = BattleManager.GetInstance().curGuardian;
        var guardian = ObjectManager.GetInstance().GetGuardian($"Guardian_{curGuardian}");
        Guardian_Mono guardian_Mono = guardian.GetComponent<Guardian_Mono>();
        guardian_Mono.guardian = GuardianList[curGuardian].Clone();
    }
}
