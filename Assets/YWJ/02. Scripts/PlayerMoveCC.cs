using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Valve.VR;
//전체 주석처리
public class PlayerMoveCC : MonoBehaviour
{
    public GameObject cameraRig;
    public float speed = 1;
    Vector3 startCamPosition;
    Vector3 dir;
    public CharacterController cc;

    float h;
    float v;

    SteamVR_Action_Boolean left;
    SteamVR_Action_Boolean right;
    SteamVR_Action_Boolean forward;
    SteamVR_Action_Boolean back;

    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;


    //PlayerState playerState;
    //  Start is called before the first frame update
    void Start()
    {

        startCamPosition = Camera.main.transform.position;
        print("처음의 카메라 포지션 값은" + startCamPosition);
        cameraRig.transform.position = Camera.main.transform.position;

        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        dir = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        // 텔레포트 모드가 아니면서 설정메뉴가 열려있지않을때
        if (!GameManager.instance.GetMoveMode() && !GameManager.instance.SettingMenuState())
        {

            //플레이어가 움직임
            //if (SteamVR_Actions.default_TrackPadUp.GetState(SteamVR_Input_Sources.LeftHand))
            //{
            //    print("TrackPadUp Click");
            //    dir = Camera.main.transform.forward;
            //    dir.y = 0;
            //    cameraRig.transform.position += dir * speed * Time.deltaTime;

            //    // 커브의 값을t에 넣어주고 y에 다시 넣어줌
            //    print(Camera.main.transform.position);
            //    if ((Mathf.Abs(Camera.main.transform.position.y) - Mathf.Abs(startCamPosition.y)) > 1)
            //    {
            //        print("앉은건감??");

            //        print("TrackPadUp Click");
            //        dir = Camera.main.transform.forward;
            //        dir.y = 0;
            //        cameraRig.transform.position += dir * speed / 2 * Time.deltaTime;
            //        //  커브의 값을t에 넣어주고 y에 다시 넣어줌
            //        print(Camera.main.transform.position);
            //    }
            //}
            //if (SteamVR_Actions.default_TrackPadDown.GetState(SteamVR_Input_Sources.LeftHand))
            //{
            //    print("TrackPadUp Click");
            //    Vector3 dir = -Camera.main.transform.forward;
            //    dir.y = 0;
            //    cameraRig.transform.position += dir * speed * Time.deltaTime;
            //}
            //if (SteamVR_Actions.default_TrackPadRight.GetState(SteamVR_Input_Sources.LeftHand))
            //{
            //    print("TrackPadUp Click");
            //    Vector3 dir = Camera.main.transform.right;
            //    dir.y = 0;
            //    cameraRig.transform.position += dir * speed * Time.deltaTime;
            //}
            //if (SteamVR_Actions.default_TrackPadLeft.GetState(SteamVR_Input_Sources.LeftHand))
            //{
            //    print("TrackPadUp Click");
            //    Vector3 dir = -Camera.main.transform.right;
            //    dir.y = 0;
            //    cameraRig.transform.position += dir * speed * Time.deltaTime;
            //}

            dir = (Camera.main.transform.forward*Convert.ToInt32(forward.GetState(hand))) + (-Camera.main.transform.forward * Convert.ToInt32(back.GetState(hand)))
                + (Camera.main.transform.right * Convert.ToInt32(right.GetState(hand))) + (-Camera.main.transform.right * Convert.ToInt32(left.GetState(hand)));

            cc.Move(dir * speed * Time.deltaTime);
        }



    }
}
