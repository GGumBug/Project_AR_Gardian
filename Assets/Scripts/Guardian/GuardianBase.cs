using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBase
{
    public string GuardianName { get; protected set; }
    public int atk { get; protected set; }
    public int hp { get; protected set; }
    public float delay { get; protected set; }
    public bool isClear { get; set; }
    public bool canAttack { get; set; }

    public virtual GuardianBase Clone()
    {
        var NewData = new GuardianBase();
        NewData.GuardianName = GuardianName;
        NewData.atk = atk;
        NewData.hp = hp;
        NewData.delay = delay;
        NewData.isClear = isClear;
        NewData.canAttack = canAttack;

        return NewData;
    }
}
