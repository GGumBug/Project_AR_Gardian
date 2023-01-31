using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static List<RewardItem> itemDatas = new List<RewardItem>()
    {
        new RewardItem("불타는심장", "\n 체력을 50 회복한다\n하지만 공격력10감소.",0,50,-10,0,0,false,false),
        new RewardItem("독칼", "\n 공격력10증가.",1,0,10,0,0,false,false),
        new RewardItem("바람의 방패", "\n 방어 딜레이가 0.1 감소한다.",2,0,0,0.1f,0,false,false),
        new RewardItem("치명적인속도", "\n 공격 딜레이가 0.3 감소한다.",3,0,0,0,0.3f,false,false),
        new RewardItem("구원", "\n 체력 30 회복한다",4,30,0,0,0,false,false),
        new RewardItem("스태틱 단검", "\n 공격 딜레이가 0.5 감소한다.\n공격력 10감소",5,0,-10,0,0.1f,false,false),
        new RewardItem("군단의 방패","\n 획득시 죽음에 이르는 피해를\n1회 막아준다",6,0,0,0,0,true,false),
        new RewardItem("무한의 대검","\n 공격력 20증가 \n공격 딜레이 0.2증가",7,0,20,0,-0.2f,false,false),
        new RewardItem("폭풍갈퀴","\n 공격력20증가 \n방어 딜레이 0.1증가",8,0,0,+0.1f,0,false,false),
        new RewardItem("금강불괴","\n 너무나 강력해 \n아직은 다룰 수 없을거같다.",9,0,0,0,0,false,true)

    };

    public static Dictionary<int, UIRewardItem> currentItems;
}
