using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMap : MonoBehaviour
{
    //static public int dokevListScore;
    //int monsterListScore; //몬스터 순번 0이면 1단계 1이면 2단계 이런식
    Image MapImg;
    public Button[] monsterBut;
    void Start()
    {
        monsterBut = GetComponentsInChildren<Button>();
        MapImg = GetComponentInChildren<Image>();
        MapImg.sprite = Resources.Load<Sprite>("Image/MainMap");
        Image monster = Instantiate(MapImg);
        Monsterbuthide();
        MonsterCount();
        //dokevListScore = monsterListScore;
    }

    void MonsterCount()//for문을 사용하면 더 좋을거같다하심 근데 어케할지 감이안잡혀서 보류
    {
        switch (BattleManager.GetInstance().monsterListScore)
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

}
