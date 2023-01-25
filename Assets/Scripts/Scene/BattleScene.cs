using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    void Start()
    {
        SpawnManager.GetInstance();
        BattleManager.GetInstance();
    }

}
