using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamplight_Guardian : GuardianBase
{
    public lamplight_Guardian(string name,int atk,int maxHp, int hp, float delay,int parryingpercentage)
    {
        this.GuardianName = name;
        this.atk = atk;
        this.maxHp = maxHp;
        this.hp = hp;
        this.delay = delay;
        this.isClear = false;
        this.canAttack = false;
        this.parryingpercentage = parryingpercentage;
    }
}
