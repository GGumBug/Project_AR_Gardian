using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    GameObject TitleUI;
    void Start()
    {
        TitleUI = Resources.Load<GameObject>("UI/TitleUI");
        GameObject titleui = (GameObject)Instantiate(TitleUI);
        AudioManager.instance.PlayBGM(1);
    }

}
