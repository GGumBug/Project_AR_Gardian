using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamplight_Guardian : GuardianBase
{
    public lamplight_Guardian(string name,int atk, int hp, float delay)
    {
        this.GuardianName = name;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.isClear = false;
    }

    public abstract Attack()
    {

    }
}