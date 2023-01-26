using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duaksini_Guardian : GuardianBase
{
    public Duaksini_Guardian(string name, int atk,int maxHp, int hp, float delay)
    {
        this.GuardianName = name;
        this.atk = atk;
        this.maxHp = maxHp;
        this.hp = hp;
        this.delay = delay;
        this.isClear = false;
        this.canAttack = false;
    }
}
