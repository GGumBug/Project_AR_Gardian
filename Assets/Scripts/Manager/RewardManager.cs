using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RewardManager : MonoBehaviour
{
    public static List<RewardItem> itemDatas = new List<RewardItem>()
    {
        new RewardItem("환단", "영묘한 효험이 있는 약 \n 체력을 50회복한다. ",0,50,0,0,0,false),
        new RewardItem("도깨비 방망이", "도깨비들이 주로 쓰는 방망이 \n 공격력 10증가",1,0,10,0,0,false),
        new RewardItem("깃털", "아무튼 깃털 \n 공격 딜레이0.25감소",2,0,0,0,0.25f,false),
        new RewardItem("붕대", "깨끗한 붕대 \n 체력을 30회복한다",3,30,0,0,0,false),
        new RewardItem("전기", "검이 빨라진다 \n 페링 딜레이0.5감소",4,0,0,0.5f,0,false),
        new RewardItem("거북이등딱지", "테스트 아이템1 \n 화염공격?",5,0,0,0,0,true),
    };

    public static Dictionary<int, UIRewardItem> currentItems;
}
