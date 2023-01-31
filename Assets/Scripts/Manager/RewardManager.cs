using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static List<RewardItem> itemDatas = new List<RewardItem>()
    {
        new RewardItem("     ", "\n 체력을 50 회복한다.",             0,50,0,0,0,false),
        new RewardItem("     ", "\n 공격 딜레이 0.1 감소한다.",       1,0,0,0,0.1f,false),
        new RewardItem("     ", "\n 체력을 30 회복한다.",             2,30,0,0,0,false),
        new RewardItem("     ", "\n 공격력 10 증가한다.",             3,0,10,0,0,false),       
        new RewardItem("     ", "\n 체력을 20 회복한다.",             4,0,0,0.25f,0,false),       
        new RewardItem("     ", "\n 공격력 30 증가한다.",             5,0,30,0,0,false),
        new RewardItem("금강불괴","\n 너무나 강력해 다룰 수 없습니다.",6,0,0,0,0,true)
    };

    public static Dictionary<int, UIRewardItem> currentItems;
}
