using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    GameObject Mainui;
    void Start()
    {
        Mainui = Resources.Load<GameObject>("UI/UIMap");
        GameObject uimain = (GameObject)Instantiate(Mainui);
        AudioManager.instance.PlayBGM(0);
        AudioManager.instance.bgAudioSource.loop = true;
    }
}
