using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class StartPlayerMove : MonoBehaviour
{
    public GameObject cameraRig;
    public float speed = 1;
    Vector3 startCamPosition;
    Vector3 dir;
    bool move = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어가 움직임
        if (SteamVR_Actions.default_TrackPadUp.GetState(SteamVR_Input_Sources.LeftHand))
        {
            //print("TrackPadUp Click");
            dir = Camera.main.transform.forward;
            dir.y = 0;
            cameraRig.transform.position += dir * speed * Time.deltaTime;
            //커브의 값을t에 넣어주고 y에 다시 넣어줌
            //print(Camera.main.transform.position);
            /*if ((Mathf.Abs(Camera.main.transform.position.y) - Mathf.Abs(startCamPosition.y)) > 1)
            {
                print("앉은건감??");

                //print("TrackPadUp Click");
                dir = Camera.main.transform.forward;
                dir.y = 0;
                cameraRig.transform.position += dir * speed / 2 * Time.deltaTime;
                //커브의 값을t에 넣어주고 y에 다시 넣어줌
                //print(Camera.main.transform.position);
            }*/
        }
        if (SteamVR_Actions.default_TrackPadDown.GetState(SteamVR_Input_Sources.LeftHand))
        {
            //print("TrackPadUp Click");
            Vector3 dir = -Camera.main.transform.forward;
            dir.y = 0;
            cameraRig.transform.position += dir * speed * Time.deltaTime;
        }
        if (SteamVR_Actions.default_TrackPadRight.GetState(SteamVR_Input_Sources.LeftHand))
        {
            //print("TrackPadUp Click");
            Vector3 dir = Camera.main.transform.right;
            dir.y = 0;
            cameraRig.transform.position += dir * speed * Time.deltaTime;
        }
        if (SteamVR_Actions.default_TrackPadLeft.GetState(SteamVR_Input_Sources.LeftHand))
        {
            //print("TrackPadUp Click");
            Vector3 dir = -Camera.main.transform.right;
            dir.y = 0;
            cameraRig.transform.position += dir * speed * Time.deltaTime;
        }
    }
}
