using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITitle : MonoBehaviour
{
    Image TitleImg;
    Button GameStart;
    // Start is called before the first frame update
    void Start()
    {
        TitleImg = GetComponentInChildren<Image>();
        GameStart = GetComponentInChildren<Button>();
        TitleImg.sprite = Resources.Load<Sprite>("Image/Title");
        Image monster = Instantiate(TitleImg);
        GameStart.onClick.AddListener(ChangeMainScene);
    }

    void ChangeMainScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
