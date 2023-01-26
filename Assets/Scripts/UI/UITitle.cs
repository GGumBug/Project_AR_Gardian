using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UITitle : MonoBehaviour
{
    public Image TitleImg;
    
    public Image BtnImg1;
    public Image BtnImg2;
    public Button GameStart;
    public TMP_Text GameStartTxt;

    void Start()
    {
        // TitleImg = GetComponentInChildren<Image>();
        // GameStart = GetComponentInChildren<Button>();
        // TitleImg.sprite = Resources.Load<Sprite>("Image/Title");
        // Image monster = Instantiate(TitleImg);
       
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().planeDistance = 11;

        GameStartTxt = GameStart.GetComponentInChildren<TMP_Text>();
        Invoke("AppearLogo", 6.5f);

        GameStart.onClick.AddListener(ChangeMainScene);

    }

    public void AppearLogo()
    {
        TitleImg.rectTransform.DOScale(1, 1f);
        TitleImg.DOFade(1, 1f).OnComplete(() =>
        {            
            BtnImg1.DOFade(1, 1f);
            BtnImg2.DOFade(1, 1f);
            BtnImg2.transform.DOLocalMoveY(-60, 1).SetRelative().SetEase(Ease.Linear);
            GameStart.image.DOFade(1, 2.5f);
            GameStartTxt.DOFade(1, 2.5f);
        });
       
        
        //var originPos = TitleImg.rectTransform.anchoredPosition.y;
        //var startPos = TitleImg.rectTransform.anchoredPosition;
        //startPos.y -= 50;

        //TitleImg.DOFade(1, 5f);
        //TitleImg.rectTransform.DOAnchorPosY(originPos, 0.7f).ChangeStartValue(startPos)
        //    .OnComplete(() => {
        //         BtnImg2.rectTransform.DOAnchorPosY(-300, 1);
        //        //
        //    });

    }

    void ChangeMainScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

}