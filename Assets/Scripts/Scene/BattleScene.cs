using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    void Start()
    {
        GuardianManager.GetInstance().GuardianList[BattleManager.GetInstance().curGuardian].canAttack = false;
        BattleManager.GetInstance().page = Page.page_0;
        SpawnManager.GetInstance();
        BattleManager.GetInstance();
        AudioManager.instance.bgAudioSource.loop = true;
        AudioManager.instance.PlayBGM(0);
        SpawnManager.GetInstance().WispCheck = true;

    }
}
