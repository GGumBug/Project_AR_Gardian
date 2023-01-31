using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PlayerState : MonoBehaviour
{
    [SerializeField] TMP_Text hp;
    [SerializeField] TMP_Text atk;
    [SerializeField] TMP_Text pd;
    [SerializeField] TMP_Text ad;

    private void Update()
    {
        hp.text = GameManager.GetInstance().NewPlayer.hp.ToString();
        atk.text = GameManager.GetInstance().NewPlayer.atk.ToString();
        pd.text = GameManager.GetInstance().NewPlayer.parryingDelay.ToString();
        ad.text = GameManager.GetInstance().NewPlayer.attackingDelay.ToString();
    }
}
