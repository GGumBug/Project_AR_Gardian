using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wisp : MonoBehaviour
{
    public void OnMouseDown()
    {
        ObjectManager.GetInstance().CreateGuardian(BattleManager.GetInstance().curGuardian);
    }
}
