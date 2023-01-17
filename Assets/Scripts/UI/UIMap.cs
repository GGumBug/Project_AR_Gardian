using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMap : MonoBehaviour
{
    public int monsterListScore; //몬스터 순번 0이면 1단계 1이면 2단계 이런식
    Image MapImg;
    public Button[] monsterBut;

    void Start()
    {
        monsterBut = GetComponentsInChildren<Button>();
        MapImg = GetComponentInChildren<Image>();
        MapImg.sprite = Resources.Load<Sprite>("Image/MainMap");
        Image monster = Instantiate(MapImg);
        Monsterhide();
        MonsterCount();

    }

    void MonsterCount()
    {
        switch (monsterListScore)
        {
            case 0:
                monsterBut[0].gameObject.SetActive(true);
                ChangeBattleScene();
                break;
            case 1:
                monsterBut[0].interactable = false;
                monsterBut[1].gameObject.SetActive(true);
                ChangeBattleScene();
                break;
            case 2:
                monsterBut[2].gameObject.SetActive(true);
                ChangeBattleScene();
                break;

        }
    }

    void Monsterhide()
    {
        for (int i = 0; i < monsterBut.Length; i++)
        {
            monsterBut[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {
        
    }
    void ChangeBattleScene()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }

}
