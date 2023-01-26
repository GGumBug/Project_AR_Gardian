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
    void RanDomItem()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomidx = Random.Range(0, RewardManager.itemDatas.Count);

            RewardItem item = RewardManager.itemDatas[randomidx];

            Object itemObejct = Resources.Load($"UI/RewardItem");
            GameObject itemGameObejct = (GameObject)Instantiate(itemObejct, itemRoot.transform);
            

            UIRewardItem uiRewardItem = itemGameObejct.GetComponent<UIRewardItem>();
            uiRewardItem.SetRefence();
            uiRewardItem.SetItemInfo(item.itemName, item.itemInfo, item.itemImg);

            RewardManager.itemDatas.RemoveAt(randomidx);
            RewardManager.currentItems.Add(item.itemImg, uiRewardItem);
        }
    }

}
