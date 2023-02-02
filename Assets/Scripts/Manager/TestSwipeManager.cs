using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipeManager : MonoBehaviour
{
    //Animator animator;

    //private Vector3 fp;   //첫 번째 터치 위치
    //private Vector3 lp;   //마지막 터치 위치
    //private float dragDistance;  //스와이프 등록을 위한 최소 거리

    //public int playerAttackDirection;

    //bool _isTouched = false;

    //void Start()
    //{
    //    dragDistance = Screen.height * 15 / 100; //dragDistance는 화면의 15% 높이입니다.
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        _isTouched = true;
    //        fp = Input.mousePosition;
    //    }

    //    if (_isTouched == false)
    //        return;

    //    if (Input.GetMouseButton(0)) // 사용자가 원터치로 화면을 터치하고 있습니다.
    //    {
    //        lp = Input.mousePosition;  //마지막 터치 위치. 목록을 사용하는 경우 생략            
    //    }

    //    if (Input.GetMouseButtonUp(0)) // 손가락이 화면에서 제거되었는지 확인
    //    {
    //        _isTouched = false;
    //        lp = Input.mousePosition;
    //        //드래그 거리가 화면 높이의 20%보다 큰지 확인
    //        if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
    //        {//드래그입니다.
    //         //드래그가 수직인지 수평인지 확인
    //            if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
    //            {   //수평 이동이 수직 이동보다 큰 경우..
    //                if ((lp.x > fp.x))  //오른쪽으로 이동한 경우)
    //                {   //오른쪽 스와이프
    //                    Debug.Log("Right Swipe");
    //                    playerAttackDirection = 3;
    //                    BattleManager.GetInstance().PlayerAttack();
    //                }
    //                else
    //                {   //왼쪽 스와이프
    //                    Debug.Log("Left Swipe");
    //                    playerAttackDirection = 1;
    //                    BattleManager.GetInstance().PlayerAttack();
    //                }
    //            }
    //            else
    //            {   //수직 이동이 수평 이동보다 큽니다.
    //                if (lp.y > fp.y)  //움직임이 올라간 경우
    //                {   //위로 스와이프
    //                    Debug.Log("Up Swipe");
    //                    playerAttackDirection = 2;
    //                    BattleManager.GetInstance().PlayerAttack();
    //                }
    //                else
    //                {   //아래로 스와이프
    //                    Debug.Log("Down Swipe");
    //                    playerAttackDirection = 0;
    //                    BattleManager.GetInstance().PlayerAttack();
    //                }
    //            }
    //        }
    //        else
    //        {   //드래그 거리가 화면 높이의 15% 미만이므로 탭입니다.
    //            Debug.Log("Tap");
    //        }
    //    }
    //}
}