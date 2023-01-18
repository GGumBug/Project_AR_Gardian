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
}
