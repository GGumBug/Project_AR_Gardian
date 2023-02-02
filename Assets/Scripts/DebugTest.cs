using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTest : MonoBehaviour
{
    [SerializeField]Button btnWisp;
    [SerializeField] Button btnsk1;
    [SerializeField] Button btnsk2;

    [SerializeField]GameObject wisp;

    public void DebugCreatWisp()
    {
        wisp = ObjectManager.GetInstance().CreateWisp();
        wisp.transform.position = SpawnManager.GetInstance().spawnPosition.position;
    }
    public void Debugski1()
    {
        GameManager.GetInstance().NewPlayer.skill_1 = true;
    }
    public void Debugsk2()
    {
        GameManager.GetInstance().NewPlayer.skill_2 = true;
    }

}
