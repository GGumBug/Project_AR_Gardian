using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{

    [SerializeField] public static List<RewardItem> itemDatas = new List<RewardItem>()
    {
        new RewardItem("환단", "영묘한 효험이 있는 약 \n 체력을 50회복한다. ",0),
        new RewardItem("도깨비 방망이", "도깨비들이 주로 쓰는 방망이 \n 공격력 2배증가",1),
        new RewardItem("깃털", "아무튼 깃털 \n 공격 딜레이감소",2),
        new RewardItem("붕대", "깨끗한 붕대 \n 체력회복",3),
        new RewardItem("전기", "검이 빨라진다 \n 페링딜레이감소",4),
        new RewardItem("거북이등딱지", "한번 막아주나 \n 무적",5)

    };

    public static Dictionary<int, UIRewardItem> currentItems = new Dictionary<int, UIRewardItem>();
}
