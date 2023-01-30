using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darksini_Guardian : GuardianBase
{
    public Darksini_Guardian(string name, int atk, int maxHp, int hp, float delay)
    {
        this.GuardianName = name;
        this.atk = atk;
        this.maxHp = maxHp;
        this.hp = hp;
        this.delay = delay;
        this.isClear = false;
        this.canAttack = false;
    }

    public override void Attack()
    {
        Debug.Log("Double Attack");
        GameManager.GetInstance().SetHp(-atk);
    }
}
