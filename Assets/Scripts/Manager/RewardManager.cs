using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{

    [SerializeField] public static List<RewardItem> itemDatas = new List<RewardItem>()
    {
        new RewardItem("환단", "체력증가",0),
        new RewardItem("도깨비 방망이", "공격력증가",1),
        new RewardItem("깃털", "딜레이감소",2),
        new RewardItem("붕대", "체력회복",3),
        new RewardItem("전기", "페링딜레이감소",4),
        new RewardItem("거북이등딱지", "무적",5)

    };

    void Update()
    {
        
    }
}
