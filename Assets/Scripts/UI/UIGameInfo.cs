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
    [SerializeField] Image infoimg;



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
            case 0:
                txtinfo.text = "게임설명";
                InfoCount += 1;
                break;
            case 1:
                txtinfo.text = "당신은 도깨비들의 왕입니다 \n도심속에서 말썽을 부리는 \n도깨비들을 잡아\n도깨비들의 왕임을 증명해주세요";
                InfoMonsterBnt.gameObject.SetActive(true);
                InfoCount += 1;
                BackBnt.gameObject.SetActive(true);
                break;
            case 2:
                txtinfo.text = "도깨비를 클릭하면\n처치 하러 갈 수 있습니다.";
                InfoImgNextChange();
                InfoCount += 1;
                infoimg.gameObject.SetActive(true);
                BackBnt.gameObject.SetActive(true);

                break;
            case 3:
                txtinfo.text = "주변을 둘러보며 도깨비불을 찾으세요.";
                InfoImgNextChange();
                InfoCount += 1;
                break;
            case 4:
                txtinfo.text = "화면을 스와이프 하면\n스와이프 한 방향에 따라 공격을 할 수 있습니다.";
                InfoImgNextChange();
                InfoCount += 1;
                break;
            case 5:
                txtinfo.text = "도깨비도 4방향으로 공격하며\n방향에 맞춰 반격 버튼을 누르면 공격을 막을 수 있습니다.";
                InfoImgNextChange();
                InfoCount += 1;
                break;
            case 6:
                txtinfo.text = "도깨비도 방어를 할 수 있으니 \n조심하세요!";
                InfoImgNextChange();
                InfoCount += 1;
                break;
            case 7:
                txtinfo.text = "도깨비를 처치하면\n보상을 획득 합니다.\n보상을 조합해서\n숨겨진 스킬을 얻어보세요!";
                InfoImgNextChange();
                InfoCount += 1;
                break;
            case 8:
                txtinfo.text = "도깨비를 모두 처치 하면\n게임을 클리어 합니다.";
                InfoImgNextChange();
                InfoCount += 1;
                break;
            case 9:
                txtinfo.text = "그럼 무운을 빕니다!";
                infoimg.gameObject.SetActive(false);
                break;

        }
    }

    void InfoBack()
    {
        switch (InfoCount)
        {
            case 1:
                txtinfo.text = "게임설명";
                break;
            case 2:
                txtinfo.text = "당신은 도깨비들의 왕입니다 \n도심속에서 말썽을 부리는 \n도깨비들을 잡아\n도깨비들의 왕임을 증명해주세요";
                InfoMonsterBnt.gameObject.SetActive(true);
                infoimg.gameObject.SetActive(false);
                BackBnt.gameObject.SetActive(false);
                break;
            case 3:
                txtinfo.text = "도깨비를 클릭하면\n처치 하러 갈 수 있습니다.";
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 4:
                txtinfo.text = "주변을 둘러보며 도깨비불을 찾으세요.";
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 5:
                txtinfo.text = "화면을 스와이프 하면\n스와이프 한 방향에 따라 공격을 할 수 있습니다.";
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 6:
                txtinfo.text = "도깨비도 4방향으로 공격하며\n방향에 맞춰 반격 버튼을 누르면 공격을 막을 수 있습니다.";
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 7:
                txtinfo.text = "도깨비도 방어를 할 수 있으니 조심하세요!";
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 8:
                txtinfo.text = "도깨비를 처치하면 보상을 획득 합니다.\n보상을 조합해서 숨겨진 스킬을 얻어보세요!";
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 9:
                txtinfo.text = "도깨비를 모두 처치 하면 게임을 클리어 합니다.";
                infoimg.gameObject.SetActive(true);
                InfoImgBackChange();
                InfoCount -= 1;
                break;
            case 10:
                txtinfo.text = "그럼 무운을 빕니다!";
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
   void InfoImgNextChange()
    {
        infoimg.sprite = Resources.Load<Sprite>($"Image/InfoImg_{InfoCount}");
    }
    void InfoImgBackChange()
    {
        infoimg.sprite = Resources.Load<Sprite>($"Image/InfoImg_{InfoCount-1}");
    }
}
