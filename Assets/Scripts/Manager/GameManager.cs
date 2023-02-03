using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region SingleTone
    private static GameManager Instance = new GameManager();

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            Instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return Instance;

    }
    #endregion

    public Player NewPlayer = new Player("비형", 40, 100, 1f, 2f);

    public int parryingDrection;
    public void SetHp(int dmg)
    {
        NewPlayer.hp += dmg;
    }

    public void Attack()
    {
        int a = BattleManager.GetInstance().curGuardian;
        GuardianBase guardian = GuardianManager.GetInstance().GetGuardianMonoBase();
        guardian.hp -= NewPlayer.atk;
    }

    public void Parrying(int b)
    {
        parryingDrection = b;

        int a = BattleManager.GetInstance().curGuardian;

        if (GuardianManager.GetInstance().GuardianList[a].canParrying && !NewPlayer.isParrying && !NewPlayer.canAttack)
        {
            NewPlayer.isParrying = true;
            GuardianManager.GetInstance().GuardianList[a].canParrying = false;
            BattleManager.GetInstance().ParryingDelay();
        }

        if (!GuardianManager.GetInstance().GuardianList[a].canParrying && !NewPlayer.isParrying && !NewPlayer.canAttack)
        {
            NewPlayer.isParrying = true;
            BattleManager.GetInstance().ParryingDelay();
        }
    }

    public void PlayerDie()
    {
        Debug.Log($"HP = {NewPlayer.hp}");
        if (NewPlayer.hp <= 0)
        {
            if (NewPlayer.skill_1 == true)
            {
                NewPlayer.hp = 1;
                NewPlayer.skill_1 = false;
                BattleManager.GetInstance().uIBattle.RefreshHP();
            }
            else
            {
                NewPlayer.hp = 0;
                Debug.Log($"HP = {NewPlayer.hp}");
                BattleManager.GetInstance().page = Page.page_0;
                BattleManager.GetInstance().uIBattle.RefreshHP();
                BattleManager.GetInstance().uIBattle.dieimg.gameObject.SetActive(true);
                AudioManager.instance.PlayBGM(5);
                for (int i = 0; i < GuardianManager.GetInstance().GuardianList.Length; i++)
                {
                    GuardianManager.GetInstance().GuardianList[i].canAttack = false;
                }
                NewPlayer.canAttack = false;
                NewPlayer.isParrying = false;
                GuardianManager.GetInstance().ResetGuardian();
                UITitle.itemDataClone.Clear();

            }
        }
    }
    public void ReTitle()
    {
        ScenesManager.GetInstance().DieTitle();
    }
    public void HealHp(int healhp)
    {
        NewPlayer.hp += healhp;
        if (NewPlayer.hp > 100)
        {
            NewPlayer.hp = 100;
        }
    }

    public void IncreaseAtk(int value)
    {
        NewPlayer.atk += value;
    }

    public void ParryingDelayDown(float pDelayDown)
    {
        NewPlayer.parryingDelay -= pDelayDown;
    }
    public void AttackDelayDown(float aDelayDown)
    {
        NewPlayer.attackingDelay -= aDelayDown;
    }
    public void Skill1true(bool skill_1)
    {
        if (NewPlayer.skill_1 == false)
        {
            NewPlayer.skill_1 = skill_1;
            return;
        }
    }
    public void Skill2true(bool skill_2)
    {
        if (NewPlayer.skill_2 == false)
        {
            NewPlayer.skill_2 = skill_2;
            return;
        }
    }
    public void SpecialDefencetrue()
    {
        if (NewPlayer.skill_1 == true && NewPlayer.skill_2 == true || NewPlayer.skill_2 == true && NewPlayer.skill_1 == true)
        {
            NewPlayer.defence = true;
            NewPlayer.skill_2 = false;
            NewPlayer.skill_1 = false;
        }
    }

}

