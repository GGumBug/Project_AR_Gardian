using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIRewardItem : MonoBehaviour
{
    public Button btnItem;
    public TMP_Text txtName;
    public TMP_Text txtInfo;
    public Image itemImage;
    public void SetRefence()
    {
        btnItem = GetComponent<Button>();

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        Image[] imgs = GetComponentsInChildren<Image>();

        txtName = texts[0];
        txtInfo = texts[1];
        itemImage = imgs[1];
    }

    public void SetItemInfo(string itemName, string itemInfo,int itemimg)
    {
        txtName.text = itemName;
        txtInfo.text = itemInfo;
        itemImage.sprite = Resources.Load<Sprite>($"Image/RewardItem_{itemimg}");
    }


}
