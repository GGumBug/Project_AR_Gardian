using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Dictionary<string, GameObject> GuardianList = new Dictionary<string, GameObject>();

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

        GuardianList.Add($"Guardian_{i}", Guardian);
        return Guardian;
    }

    public GameObject GetGuardian(string key)
    {
        if (GuardianList.ContainsKey(key))
            return GuardianList[key];

        return null;
    }

    public void ClearObject()
    {
        GuardianList.Clear();
    }
}
