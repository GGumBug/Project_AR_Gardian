using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region instance

    private static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion
    public int monsterListScore;//몬스터 순번 0이면 1단계 1이면 2단계 이런식
    void Update()
    {

    }
    
    public void BattleStart()
    {
        ObjectManager.GetInstance().CreateGuardian(monsterListScore);
    }
}
