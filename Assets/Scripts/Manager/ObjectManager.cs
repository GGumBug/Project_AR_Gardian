using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    #region instance

    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public GameObject CreateWisp()
    {
        Object characterWisp = Resources.Load($"Object/Wisp_{BattleManager.GetInstance().curGuardian}");
        GameObject wisp = (GameObject)Instantiate(characterWisp, SpawnManager.GetInstance().spawnPosition);

        return wisp;
    }
    public GameObject CreateGuardian(int i)
    {
        Object GuardianObj = Resources.Load($"Object/Guardian_{i}");
        GameObject Guardian = (GameObject)Instantiate(GuardianObj, SpawnManager.GetInstance().spawnPosition);
        return Guardian;
    }
}
