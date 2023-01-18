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

    int InfoCount = 1;
    TMP_Text txtinfo;

    void Start()
    {
        txtinfo = GetComponentInChildren<TMP_Text>();
        NextBnt.onClick.AddListener(InfoNext);
        BackBnt.onClick.AddListener(InfoBack);

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
                InfoMonsterBnt.gameObject.SetActive(false);
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
                txtinfo.text = "게임 설명.";
                BackBnt.gameObject.SetActive(false);
                break;
            case 2:
                txtinfo.text = "버튼을 누르면 도깨비를 잡으러갑니다.";
                InfoMonsterBnt.gameObject.SetActive(true);
                InfoCount -= 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 3:
                InfoMonsterBnt.gameObject.SetActive(false);
                txtinfo.text = "대강 체력바 어쩌구 등등.";
                InfoCount -= 1;
                break;
            case 4:
                break;
            case 5:
                break;

        }

    }
}
