using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SingleTone
    private static GameManager Instance = new GameManager();

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            Instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return Instance;

    }
    #endregion

    public Player NewPlayer = new Player("비형", 10, 100);

    public void SetHp(int dmg)
    {
        NewPlayer.hp += dmg;
    }

    public void Attack()
    {
        int a = BattleManager.GetInstance().curGuardian;
        GuardianManager.GetInstance().GuardianList[a].hp -= NewPlayer.atk;
    }

    public void Parrying()
    {
        int a = BattleManager.GetInstance().curGuardian;

        if (GuardianManager.GetInstance().GuardianList[a].canParrying)
        {
            BattleManager.GetInstance().GuardianStun();
        }
    }
}
