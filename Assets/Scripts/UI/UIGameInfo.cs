using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameInfo : MonoBehaviour
{
    [SerializeField] Button NextBnt;
    [SerializeField] Button BackBnt;
    [SerializeField] Button InfoMonsterBnt;
    [SerializeField] Button ExitBnt;
    [SerializeField] Image blackimg;
    [SerializeField] GameObject infogo;


    public int InfoCount = 1;
    TMP_Text txtinfo;

    void Start()
    {
        StartCoroutine("FadeIn");
        blackimg = GetComponentInChildren<Image>();
        txtinfo = GetComponentInChildren<TMP_Text>();
        NextBnt.onClick.AddListener(InfoNext);
        BackBnt.onClick.AddListener(InfoBack);
        ExitBnt.onClick.AddListener(ExitClick);

    }

    void InfoNext()
    {
        switch (InfoCount)
        {
            case 1:
                txtinfo.text = "당신은 도깨비들의 왕입니다 \n도심속에서 말썽을 부리는 \n도깨비들을 잡아\n도깨비들의 왕임을 증명해주세요";
                InfoMonsterBnt.gameObject.SetActive(true);
                InfoCount += 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 2:
                txtinfo.text = "불꽃이있는 도깨비를 눌러\n도깨비를 잡을러 갑니다.";
                InfoCount += 1;
                break;
            case 3:
                txtinfo.text = "도깨비를 잡으면\n보상 카드를 통해 캐릭터를 강화할수있습니다.";
                InfoCount += 1;
                break;
            case 4:
                txtinfo.text = "죽어도 걱정하지마세요 \n타이틀 화면으로 돌아가지만\n능력치를 전승한채로 환생 할수있습니다.";
                break;
            case 5:

                break;

        }
    }

    void InfoBack()
    {
        switch (InfoCount)
        {
            case 1:
                break;
            case 2:
                txtinfo.text = "당신은 도깨비들의 왕입니다 \n도심속에서 말썽을 부리는 \n도깨비들을 잡아\n도깨비들의 왕임을 증명해주세요";
                BackBnt.gameObject.SetActive(false);
                InfoCount -= 1;
                break;
            case 3:
                txtinfo.text = "불꽃이있는 도깨비를 눌러\n도깨비를 잡을러 갑니다.";
                InfoMonsterBnt.gameObject.SetActive(true);
                InfoCount -= 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 4:
                txtinfo.text = "도깨비를 잡으면\n보상 카드를 통해 캐릭터를 강화할수있습니다.";
                InfoCount -= 1;
                break;
            case 5:
                txtinfo.text = "죽어도 걱정하지마세요 \n타이틀 화면으로 돌아가지만\n능력치를 전승한채로 환생 할수있습니다.";
                InfoCount -= 1;
                break;

        }

    }

    void ExitClick()
    {
        infogo.gameObject.SetActive(false);
    }
    IEnumerator FadeIn()
    {
        while (blackimg.color.a < 0.7)
        {
            float alpha = blackimg.color.a;
            alpha += 0.012f;
            blackimg.color = new Color(blackimg.color.r, blackimg.color.g, blackimg.color.b, alpha);
            yield return null;
        }

    }
}
