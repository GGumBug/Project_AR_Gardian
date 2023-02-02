using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    void Start()
    {
        GuardianManager.GetInstance().GuardianList[BattleManager.GetInstance().curGuardian].canAttack = false;
        SpawnManager.GetInstance();
        BattleManager.GetInstance();
        AudioManager.instance.bgAudioSource.loop = true;
        AudioManager.instance.PlayBGM(0);
    }
}
