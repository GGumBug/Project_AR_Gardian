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

    [Header("Bool")]
    public bool canAttack;
    public bool parrying;
    public bool isParrying {
        get { return parrying; }
        set {
            parrying = value; 
        }
    }

    public Player(string name, int atk, int hp)
    {
        playerName = name;
        this.atk = atk;
        this.hp = hp;
        canAttack = false;
        isParrying = false;
    }
}
