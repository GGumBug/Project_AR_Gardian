using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIitem : MonoBehaviour
{
    public HorizontalLayoutGroup itemRoot;


    void Start()
    {
        RanDomItem();
    }
    public void RanDomItem()
    {
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
}
