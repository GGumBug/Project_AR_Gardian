using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UITitle : MonoBehaviour
{
    public static List<RewardItem> itemDataClone;

    [SerializeField] Image TitleImg;
    [SerializeField] Image GrdnIcon;
    [SerializeField] Button GameStart;
    [SerializeField] Button SkipBnt;
    [SerializeField] ParticleSystem ps;


    void Start()
    {
       
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().planeDistance = 11;

        Invoke("AppearLogo", 6.5f);
        SkipBnt.onClick.AddListener(SkipTouch);
        GameStart.onClick.AddListener(ChangeMainScene);

        itemDataClone = new List<RewardItem>(RewardManager.itemDatas);
        RewardItemClone();

    }

    public void AppearLogo()
    {
        TitleImg.rectTransform.DOScale(1, 1f);
        TitleImg.DOFade(1, 1f).OnComplete(() =>
        {
            GameStart.image.DOFade(1, 2f);
            GrdnIcon.DOFade(1, 3f);
            
        });       

    }

    void ChangeMainScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
    void RewardItemClone()
    {
        RewardManager.currentItems = new Dictionary<int, UIRewardItem>();
        for (int i = 0; i < RewardManager.itemDatas.Count; i++)
        {
            itemDataClone[i] = RewardManager.itemDatas[i];
            if (GameManager.GetInstance().NewPlayer.skill_1 == true)
            {
                itemDataClone.RemoveAt(6);
            }
            if(GameManager.GetInstance().NewPlayer.skill_2 == true)
            {
                itemDataClone.RemoveAt(9);
            }
            if (GameManager.GetInstance().NewPlayer.defence == true)
            {
                itemDataClone.RemoveAt(6);
                itemDataClone.RemoveAt(9);
            }

        }
    }
    void SkipTouch()
    {
        CancelInvoke("AppearLogo");
        ps.gameObject.SetActive(false);
        AudioManager.instance.PlayBGM(0);
        TitleImg.rectTransform.DOScale(1, 0.1f);
        TitleImg.DOFade(1, 0.1f).OnComplete(() =>
        {
            GameStart.image.DOFade(1,0.1f);
            GrdnIcon.DOFade(1,0.1f);
        });
        SkipBnt.gameObject.SetActive(false);
    }
}