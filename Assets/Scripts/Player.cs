using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{ 
    [Header("State")]
    string playerName;
    public int atk;
    public int hp;

    [Header("Bool")]
    public bool canAttack;
    public bool isParrying;

    public Player(string name, int atk, int hp)
    {
        playerName = name;
        this.atk = atk;
        this.hp = hp;
        canAttack = false;
        isParrying = false;
    }
}
