using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWisp : MonoBehaviour
{
    [SerializeField] Button btnSpawnGuardian;

    public void OnMouseDown()
    {
        ObjectManager.GetInstance().CreateGuardian(BattleManager.GetInstance().curGuardian);
    }
}
