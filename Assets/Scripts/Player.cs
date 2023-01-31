using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //*MonoBehaviour는 씬이 끝나면 소멸하기 때문에 C#스크립트로 생성
    [Header("State")]
    string playerName;
    public int atk;
    public int hp;
    public float parryingDelay;
    public float attackingDelay;


    [Header("Bool")]
    public bool canAttack;
    public bool isParrying;
    public bool skill_1 = false;
    public bool skill_2 = false;
    public bool defence = false;

    public Player(string name, int atk, int hp, float parryingDelay, float attackingDelay)
    {
        playerName = name;
        this.atk = atk;
        this.hp = hp;
        this.parryingDelay = parryingDelay;
        this.attackingDelay = attackingDelay;
        canAttack = false;
        isParrying = false;
    }
}
