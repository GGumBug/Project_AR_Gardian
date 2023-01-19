using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMap : MonoBehaviour
{
    GuardianBase dokevbase;
    Image MapImg;
    public Button[] monsterBut;
    public GameObject gameInfocanvas;
    void Start()
    {
        monsterBut = GetComponentsInChildren<Button>();
        MapImg = GetComponentInChildren<Image>();
        MapImg.sprite = Resources.Load<Sprite>("Image/MainMap");
        Image monster = Instantiate(MapImg);
        Monsterbuthide();
        //monsterBut[0].gameObject.SetActive(true);
        //monsterBut[0].onClick.AddListener(ChangeBattleScene);
        MonsterCount();
        monsterBut[3].gameObject.SetActive(true);
        monsterBut[3].onClick.AddListener(OpenGameInfo);
    }

    void MonsterCount()//for문을 사용하면 더 좋을거같다하심 근데 어케할지 감이안잡혀서 보류
    {
        //for (int i = 0; i < monsterBut.Length - 1; i++)//이경우 0번째 버튼은 이미 켜져있어야하는데 0번째 몬스터를 잡을면 0번째 버튼이 켜진다 monsterBut[i+1]? 이게 맞는가?
        //{
        //    if (GuardianManager.GetInstance().GuardianList[i].isClear == true)
        //    {
        //        monsterBut[i].gameObject.SetActive(true);
        //        monsterBut[i].onClick.AddListener(ChangeBattleScene);

        //        return;
        //    }
        //}
        switch (BattleManager.GetInstance().curGuardian)
        {
            case 0:
                monsterBut[0].gameObject.SetActive(true);
                monsterBut[0].onClick.AddListener(ChangeBattleScene);
                break;
            case 1:
                monsterBut[0].interactable = false;
                monsterBut[1].gameObject.SetActive(true);
                monsterBut[1].onClick.AddListener(ChangeBattleScene);
                break;
            case 2:
                monsterBut[0].interactable = false;
                monsterBut[1].interactable = false;
                monsterBut[3].onClick.AddListener(ChangeBattleScene);
                monsterBut[2].gameObject.SetActive(true);
                break;

        }
    }

    void Monsterbuthide()
    {
        for (int i = 0; i < monsterBut.Length; i++)
        {
            monsterBut[i].gameObject.SetActive(false);
        }
    }
    void ChangeBattleScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }

    void OpenGameInfo()
    {
        gameInfocanvas.gameObject.SetActive(true);
    }
}
