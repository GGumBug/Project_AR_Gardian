using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector3 fp;   //첫 번째 터치 위치
    private Vector3 lp;   //마지막 터치 위치
    private float dragDistance;  //스와이프 등록을 위한 최소 거리
    bool isTouched;

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance는 화면의 15% 높이입니다.
    }

    void Update()
    {
        if (Input.touchCount == 1) // 사용자가 원터치로 화면을 터치하고 있습니다.
        {
            
            Touch touch = Input.GetTouch(0); // 터치하기
            if (touch.phase == TouchPhase.Began) // 첫 번째 터치를 확인합니다 .
            {
                isTouched = true;
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // 이동 ​​위치를 기준으로 마지막 위치 업데이트
            {
                if (isTouched == false)
                    return;

                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) // 손가락이 화면에서 제거되었는지 확인
            {
                if (isTouched == false)
                    return;

                isTouched = false;
                lp = touch.position;  //마지막 터치 위치. 목록을 사용하는 경우 생략

                //드래그 거리가 화면 높이의 20%보다 큰지 확인
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//드래그입니다.
                 //드래그가 수직인지 수평인지 확인
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //수평 이동이 수직 이동보다 큰 경우..
                        if ((lp.x > fp.x))  //오른쪽으로 이동한 경우)
                        {   //오른쪽 스와이프
                            Debug.Log("Right Swipe");
                            BattleManager.GetInstance().PlayerAttack();
                        }
                        else
                        {   //왼쪽 스와이프
                            Debug.Log("Left Swipe");
                            BattleManager.GetInstance().PlayerAttack();
                        }
                    }
                    else
                    {   //수직 이동이 수평 이동보다 큽니다.
                        if (lp.y > fp.y)  //움직임이 올라간 경우
                        {   //위로 스와이프
                            Debug.Log("Up Swipe");
                            BattleManager.GetInstance().PlayerAttack();
                        }
                        else
                        {   //아래로 스와이프
                            Debug.Log("Down Swipe");
                            BattleManager.GetInstance().PlayerAttack();
                        }
                    }
                }
                else
                {   //드래그 거리가 화면 높이의 15% 미만이므로 탭입니다.
                    Debug.Log("Tap");
                }
            }
        }
    }
}
