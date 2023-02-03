using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBase
{
    public string GuardianName { get; protected set; }
    public int atk { get; protected set; }
    public int maxHp { get; set; }
    public int hp { get; set; }
    public float delay { get; protected set; }
    public bool isClear { get; set; }
    public bool canAttack { get; set; }
    public bool canParrying { get; set; }
    public int parryingpercentage { get; set; }

    Animator guardianAnimator;

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
        NewData.parryingpercentage = parryingpercentage;

        return NewData;
    }

    public virtual void StartAniMation()
    {
        int ran = Random.Range(0, 4);
        GuardianManager.GetInstance().attackDirection = ran;

        switch (GuardianManager.GetInstance().attackDirection)
        {
            case 0:
                // 내려찍기
                FindGuardianAnimator();
                guardianAnimator.SetTrigger("G_Top");
                break;
            case 1:
                //우공격
                FindGuardianAnimator();
                guardianAnimator.SetTrigger("G_Right");
                break;
            case 2:
                //올려치기
                FindGuardianAnimator();
                guardianAnimator.SetTrigger("G_Bottom");
                break;
            case 3:
                //좌공격
                FindGuardianAnimator();
                guardianAnimator.SetTrigger("G_Left");

                break;
        }
    }

    public virtual void Attack()
    {
        GameManager.GetInstance().SetHp(-atk);
    }

    public virtual void ParryingCheck()
    {
            BattleManager.GetInstance().GuardianStun();
    }

    void FindGuardianAnimator()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Guardian");
        guardianAnimator = go.GetComponentInChildren<Animator>();
    }
}
