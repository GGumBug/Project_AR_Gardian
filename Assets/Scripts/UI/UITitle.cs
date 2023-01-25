using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UITitle : MonoBehaviour
{
    public Image TitleImg;
    public Button GameStart;
    public Image BtnImg2;
    // Start is called before the first frame update
    void Start()
    {
        // TitleImg = GetComponentInChildren<Image>();
        // GameStart = GetComponentInChildren<Button>();
        // TitleImg.sprite = Resources.Load<Sprite>("Image/Title");
        // Image monster = Instantiate(TitleImg);
        GameStart.onClick.AddListener(ChangeMainScene);

        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().planeDistance = 11;

        BtnImg2.rectTransform.DOAnchorPosY(-300, 1);
    }

    void ChangeMainScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
    public void AppearLogo()
    {
        var originPos = TitleImg.rectTransform.anchoredPosition.y;
        var startPos = TitleImg.rectTransform.anchoredPosition;
        startPos.y -= 50;

        TitleImg.DOFade(1, 0.5f);
        TitleImg.rectTransform.DOAnchorPosY(originPos, 0.7f).ChangeStartValue(startPos)
            .OnComplete(() => {
                //
            });
    }
}