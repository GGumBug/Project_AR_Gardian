using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static List<RewardItem> itemDatas = new List<RewardItem>()
    {
        new RewardItem("불타는심장", "\n 체력을 50 회복\n공격력10감소.",0,50,-10,0,0,false,false),
        new RewardItem("독칼", "\n 공격력 20 증가.",1,0,20,0,0,false,false),
        new RewardItem("바람의 방패", "\n 방어딜레이0.2감소.",2,0,0,0.2f,0,false,false),
        new RewardItem("치명적인속도", "\n 공격딜레이0.3감소.",3,0,0,0,0.3f,false,false),
        new RewardItem("구원", "\n 체력 30 회복",4,30,0,0,0,false,false),
        new RewardItem("스태틱 단검", "\n공격딜레이 0.5감소\n공격력 10 감소",5,0,-10,0,0.5f,false,false),
        new RewardItem("군단의 방패","\n 획득시 죽음을\n1회 막아준다\n다만 특별한공격은\n막지 못한다.",6,0,0,0,0,true,false),
        new RewardItem("무한의 대검","\n 공격력 30 증가 \n공격딜레이0.1증가",7,0,20,0,-0.1f,false,false),
        new RewardItem("폭풍갈퀴","\n 공격력20증가 \n방어딜레이0.1증가",8,0,20,-0.1f,0,false,false),
        new RewardItem("금강불괴","\n 어디에 사용하는지 모르겠다\n 하지만 굉장히\n중요한듯 하다.",9,0,0,0,0,false,true)

    };

    public static Dictionary<int, UIRewardItem> currentItems;
}
