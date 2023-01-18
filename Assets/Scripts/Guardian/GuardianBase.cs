using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBase : MonoBehaviour
{
    public string GuardianName;
    public int atk;
    public int hp;
    public float delay;
    public bool isClear;

    public string GetGuardianName()
    {
        return GuardianName;
    }

    public void SetGuardianName(string name)
    {
        GuardianName = name;
    }
}
