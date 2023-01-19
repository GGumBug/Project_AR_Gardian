using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [Header("State")]
    string playerName;
    public int atk;
    public int hp;

    [Header("Bool")]
    public bool canAttack;

    public Player(string name, int atk, int hp)
    {
        playerName = name;
        this.atk = atk;
        this.hp = hp;
        canAttack = false;
    }

    private void Start()
    {
        GameManager.GetInstance().NewPlayer = this;
    }
}
