using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UITitle : MonoBehaviour
{
    public static List<RewardItem> itemDataClone;

    public Image TitleImg;    
    public Image GrdnIcon;
    public Button GameStart;

    void Start()
    {
        // TitleImg = GetComponentInChildren<Image>();
        // GameStart = GetComponentInChildren<Button>();
        // TitleImg.sprite = Resources.Load<Sprite>("Image/Title");
        // Image monster = Instantiate(TitleImg);
       
        GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Canvas>().planeDistance = 11;

        Invoke("AppearLogo", 6.5f);

        GameStart.onClick.AddListener(ChangeMainScene);
        itemDataClone = new List<RewardItem>(RewardManager.itemDatas);
        RewardItemClone();
        testtt();

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
        }
    }
    void testtt()
    {
        for (int i = 0; i < itemDataClone.Count; i++)
        {
            Debug.Log($"{itemDataClone[i].itemName}\n{itemDataClone[i].itemInfo}\n{itemDataClone[i].itemImg}\n{itemDataClone[i].itemHp}\n{itemDataClone[i].itemAtk}\n{itemDataClone[i].itemparryingDelay}\n{itemDataClone[i].itemattackingDelay}");

        }
    }
}