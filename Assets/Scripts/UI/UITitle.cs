using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITitle : MonoBehaviour
{
    Image TitleImg;
    // Start is called before the first frame update
    void Start()
    {
        TitleImg = GetComponentInChildren<Image>();
        TitleImg.sprite = Resources.Load<Sprite>("Image/Title");
        Image monster = (Image)Instantiate(TitleImg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
