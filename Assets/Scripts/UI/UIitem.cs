using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class UIitem : MonoBehaviour
{
    public HorizontalLayoutGroup itemRoot;
    public Image Bgimg;

    void Start()
    {
        RanDomItem();
        Fadein();
    }
    public void RanDomItem()
    {
        AudioManager.instance.bgAudioSource.loop = false;
        AudioManager.instance.PlayBGM(4);

        for (int i = 0; i < 3; i++)
        {
            int randomidx = Random.Range(0, UITitle.itemDataClone.Count);

            RewardItem item = UITitle.itemDataClone[randomidx];

            Object itemObejct = Resources.Load($"UI/RewardItem");
            GameObject itemGameObejct = (GameObject)Instantiate(itemObejct, itemRoot.transform);
            
            UIRewardItem uiRewardItem = itemGameObejct.GetComponent<UIRewardItem>();
            uiRewardItem.SetRefence();
            uiRewardItem.SetItemInfo(item);

            UITitle.itemDataClone.RemoveAt(randomidx);
            RewardManager.currentItems.Add(item.itemImg, uiRewardItem);
        }
    }
    void Fadein()
    {
        Bgimg.DOFade(0.85f, 1f);
    }

}
