using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBase
{
    public string GuardianName { get; protected set; }
    public int atk { get; protected set; }
    public int maxHp { get; set; }
    public int hp { get; set; }
    public int attackDirection;
    public float delay { get; protected set; }
    public bool isClear { get; set; }
    public bool canAttack { get; set; }
    public bool canParrying { get; set; }


    public virtual GuardianBase Clone()
    {
        var NewData = new GuardianBase();
        NewData.GuardianName = GuardianName;
        NewData.atk = atk;
        NewData.maxHp = maxHp;
        NewData.hp = hp;
        NewData.delay = delay;
        NewData.isClear = isClear;
        NewData.canAttack = canAttack;

        return NewData;
    }

    public virtual void Attack()
    {
        int ran = Random.Range(0, 4);
        attackDirection = ran;

        switch (attackDirection)
        {
            case 0:
                // 내려찍기
                ConfirmAttack();
                break;
            case 1:
                //우공격
                ConfirmAttack();
                break;
            case 2:
                //올려치기
                ConfirmAttack();
                break;
            case 3:
                //좌공격
                ConfirmAttack();
                break;
        }
    }

    void ConfirmAttack()
    {
        int p = GameManager.GetInstance().parryingDrection;

        if (GameManager.GetInstance().NewPlayer.isParrying && attackDirection == p)
        {
            BattleManager.GetInstance().GuardianStun();
            return;
        }
        GameManager.GetInstance().SetHp(-atk);
    }
}
