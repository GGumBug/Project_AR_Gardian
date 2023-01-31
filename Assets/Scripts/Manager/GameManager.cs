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

    public Player NewPlayer = new Player("비형", 50, 100, 1f, 2f);

    public int parryingDrection;
    GuardianBase gb;
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
        if (NewPlayer.hp <= 0)
        {
            NewPlayer.hp = 0;
            BattleManager.GetInstance().uIBattle.RefreshHP();
            BattleManager.GetInstance().uIBattle.BattleInfo("YOU DIED");
            BattleManager.GetInstance().uIBattle.dieimg.gameObject.SetActive(true);
            BattleManager.GetInstance().page = Page.page_0;
            GuardianManager.GetInstance().ResetGuardian();
            UITitle.itemDataClone.Clear();
        }
    }
    public void ReTitle()
    {
        ScenesManager.GetInstance().DieTitle();
    }
    public void HealHp(int healhp)
    {
        NewPlayer.hp += healhp;
        if(NewPlayer.hp > 100)
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
    public void Skilltrue(bool skill_1)
    {
        if(NewPlayer.skill_1 == false)
        {
            NewPlayer.skill_1 = skill_1;
        }
    }
    public void SkillBtnClick(Button Btn)
    {
        Debug.Log("스킬발동 성공");
        NewPlayer.skill_1 = false;
        Btn.gameObject.SetActive(false);
    }
}

