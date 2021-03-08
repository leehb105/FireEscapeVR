using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMaskGrab : MonoBehaviour
{
    bool isMaskGrab;
    GameObject mask;
    public GameObject maskGrabPoint;
    // Start is called before the first frame update
    void Start()
    {
        isMaskGrab = false;
    }
    // Update is called once per frame
    void Update()
    {
        MaskGrab();
    }
    //마스크에 닿았으면 상태 트루 전환
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Mask"))
        {
            print("마스크 트리거 엔터 들어오나");
            isMaskGrab = true;
        }
    }
    //마스크에 안 닿았으면 상태 false 전환
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("Mask"))
        {
            print("마스크 트리거 엑시트 들어오나");
            isMaskGrab = false;
        }
    }
    public void MaskGrab() {
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (isMaskGrab)
            {
                mask = GameObject.FindGameObjectWithTag("Mask").gameObject;
                print("마스크 트리거 작동");
                transform.position = maskGrabPoint.transform.position;
                mask.transform.parent = transform;
                //maskGrabPoint.transform.position = transform.position;
                mask.transform.localEulerAngles = new Vector3(90, transform.rotation.y, transform.rotation.z);
                isMaskGrab = false;
            }
        }
    }
    
}
