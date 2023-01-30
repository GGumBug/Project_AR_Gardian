using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMap : MonoBehaviour
{
    Image MapImg;
    public Button[] monsterBut;
    public GameObject gameInfocanvas;
    public Image GetGrdn;
    public Button ExitBtn;

    void Start()
    {
        monsterBut = GetComponentsInChildren<Button>();
        MapImg = GetComponentInChildren<Image>();
        MapImg.sprite = Resources.Load<Sprite>("Image/MainMap");
        Image monster = Instantiate(MapImg);
        MonsterCount();
        monsterBut[3].gameObject.SetActive(true);
        monsterBut[3].onClick.AddListener(OpenGameInfo);
    }

    void MonsterCount()
    {
        for (int i = 0; i < GuardianManager.GetInstance().GuardianList.Length; i++)
        {
            if (GuardianManager.GetInstance().IsOpenGardian(i) == false)
            {
               // monsterBut[i].image.sprite = Resources.Load<Sprite>("Image/GetGuardianBtnImg");
               // monsterBut[i].image.color = new Color(1, 1, 1, 1);
                BattleManager.GetInstance().curGuardian = i;
                monsterBut[i].onClick.AddListener(ChangeBattleScene);
                GetGrdn.transform.position = monsterBut[i].transform.position;
                return;
            }
            if (GuardianManager.GetInstance().IsOpenGardian(i) == true)
            {
                monsterBut[i].image.sprite = Resources.Load<Sprite>("Image/ClearFire");

            }

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

