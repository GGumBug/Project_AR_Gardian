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
                txtinfo.text = "버튼을 누르면 도깨비를 잡으러갑니다.";
                InfoMonsterBnt.gameObject.SetActive(true);
                InfoCount += 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 2:
                txtinfo.text = "대강 체력바 어쩌구 등등.";
                InfoCount += 1;
                break;
            case 3:
                break;
            case 4:
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
                txtinfo.text = "게임 설명.";
                BackBnt.gameObject.SetActive(false);
                InfoCount -= 1;
                break;
            case 3:
                txtinfo.text = "버튼을 누르면 도깨비를 잡으러갑니다.";
                InfoMonsterBnt.gameObject.SetActive(true);
                InfoCount -= 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 4:
                txtinfo.text = "대강 체력바 어쩌구 등등.";
                InfoCount -= 1;
                break;
            case 5:
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
