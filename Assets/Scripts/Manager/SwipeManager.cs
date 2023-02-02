using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector3 fp;   
    private Vector3 lp;   
    private float dragDistance;  
    bool isTouched;
    public int playerAttackDirection;
    void Start()
    {
        dragDistance = Screen.height * 15 / 100; 
    }

    void Update()
    {
        if (Input.touchCount == 1) 
        {
            
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began)
            {
                isTouched = true;
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (isTouched == false)
                    return;

                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (isTouched == false)
                    return;

                isTouched = false;
                lp = touch.position; 

                
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   
                        if ((lp.x > fp.x)) 
                        {   
                            playerAttackDirection = 3;
                            BattleManager.GetInstance().PlayerAttack();
                        }
                        else
                        {   
                            playerAttackDirection = 1;
                            BattleManager.GetInstance().PlayerAttack();
                        }
                    }
                    else
                    {   
                        if (lp.y > fp.y)  
                        {   
                            playerAttackDirection = 2;
                            BattleManager.GetInstance().PlayerAttack();
                        }
                        else
                        {   
                            playerAttackDirection = 0;
                            BattleManager.GetInstance().PlayerAttack();
                        }
                    }
                }
                else
                {   
                    Debug.Log("Tap");
                }
            }
        }
    }
}
