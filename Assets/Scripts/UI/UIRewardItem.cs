using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIRewardItem : MonoBehaviour
{
    private int _itemimgKey;

    public CanvasGroup cGroup;

    RewardItem rewarditem;
    UIBattle uibattle;
    public Button btnItem;
    public TMP_Text txtName;
    public TMP_Text txtInfo;
    public Image bgImage;
    public Image itemImage;

    public void SetRefence()
    {
        btnItem = GetComponent<Button>();
        btnItem.onClick.AddListener(ItemSelect);

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        Image[] imgs = GetComponentsInChildren<Image>();

        txtName = texts[0];
        txtInfo = texts[1];
        bgImage = imgs[0];
        itemImage = imgs[1];

        bgImage.DOFade(1f, 3f);
        itemImage.DOFade(1f, 3f);

        cGroup = GetComponent<CanvasGroup>();

    }

    public void SetItemInfo(RewardItem data)
    {
        rewarditem = data;

        txtName.text = rewarditem.itemName;
        txtInfo.text = rewarditem.itemInfo;

        _itemimgKey = rewarditem.itemImg;

        itemImage.sprite = Resources.Load<Sprite>($"Image/RewardItem_{rewarditem.itemImg}");
    }

    void ItemSelect()
    {
        Vector3 Upscale = new Vector3(1.1f, 1.1f, 1.1f);
        transform.DOScale(Upscale, 0.25f);

        Vector3 downscale = new Vector3(1f, 1f, 1f);
        transform.DOScale(downscale, 0.5f).SetDelay(0.25f);

        foreach (var curitem in RewardManager.currentItems)
        {
            if (curitem.Key != _itemimgKey)
                curitem.Value.cGroup.DOFade(0, 0.5f);
            cGroup.DOFade(0f, 1.5f).SetDelay(1.5f);
        }
        ScenesManager.GetInstance().EndBattle();
        SelectReward();
        uibattle.RefreshHP();
    }
    public void SelectReward()
    {
        GameManager.GetInstance().HealHp(rewarditem.itemHp);
        GameManager.GetInstance().IncreaseAtk(rewarditem.itemAtk);
        GameManager.GetInstance().ParryingDelayDown(rewarditem.itemparryingDelay);
        GameManager.GetInstance().AttackDelayDown(rewarditem.itemattackingDelay);
        GameManager.GetInstance().Skill1true(rewarditem.skill_1);
        GameManager.GetInstance().Skill2true(rewarditem.skill_2);
        GameManager.GetInstance().SpecialDefencetrue();
    }
}
