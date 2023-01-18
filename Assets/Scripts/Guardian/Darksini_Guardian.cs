using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darksini_Guardian : GuardianBase
{
    public Darksini_Guardian(string name, int atk, int hp, float delay)
    {
        this.GuardianName = name;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.isClear = false;
    }

    public override void Attack()
    {
        GameManager.GetInstance().SetHp(-atk);
        GameManager.GetInstance().SetHp(-atk);
        GameManager.GetInstance().SetHp(-atk);
    }
}
