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
    public int curGuardian;//몬스터 순번 0이면 1단계 1이면 2단계 이런식

    void Update()
    {

    }
    public void BattleStart()
    {

    }
    public void GuardianAppear()
    {
        ObjectManager.GetInstance().CreateGuardian(curGuardian);
    }

    void TouchGuardian() // 나중에머 도깨비불에 터치하면 모델링 생성되겠금하는 함수 아직안씀 ㅇㅇ
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            {
                GuardianAppear();
            }
        }

    }
}
