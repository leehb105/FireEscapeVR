using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Valve.VR;

public class PlayerGrab : MonoBehaviour
{
    GameObject FE;
    GameObject FEHandPoint;
    Rigidbody rb;
    bool isFETrigger;
    // Start is called before the first frame update
    void Start()
    {
        FE = GameObject.FindGameObjectWithTag("FE").gameObject;
        FEHandPoint = GameObject.FindGameObjectWithTag("HandPoint").gameObject;
        rb = FE.GetComponent<Rigidbody>();
    }
    //istrigger의 상태가 true일 때만 소화기 상태를 1로 주고 소화기 잡은상태 조절
    public void FEGrab()
    {
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (isFETrigger)
            {
                //잡아야 함
                if (FEState.instance.getState() == 0)
                {
                    //FE.transform.rotation = Quaternion.Euler(0, 270, 0);
                    //소화기를 잡으면 중력을 해제
                    rb.useGravity = false;
                    if(PinGrab.instance.pinState == false)//핀이 없으면 
                    {
                        FEState.instance.setState(2);//소화기 상태 노핀
                        print("소화기 상태 노핀");
                    }
                    else
                    {
                        FEState.instance.setState(1);//소화기 상태 그랩
                        print("소화기 상태 그랩");
                    }

                }
                //안 잡아야 함
                else if (FEState.instance.getState() !=0)
                {
                    print("놓아지나?");
                    //소화기를 놓으면 중력 설정
                    rb.useGravity = true;
                    FEState.instance.setState(0);//소화기 놓은 상태
                    FE.transform.parent = null;
                }
            }
        }
        if (FEState.instance.getState() !=0)
        {
            //FE.transform.position = transform.position;
            FEHandPoint.transform.position = transform.position;
            
            FE.transform.parent = transform;
            FE.transform.localEulerAngles = new Vector3(transform.rotation.x, 200, transform.rotation.z);

        }
    }
    //소화기에 닿았으면 상태 트루 전환
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("FE"))
        {
            isFETrigger = true;
        }
    }
    //소화기에 안 닿았으면 상태 false 전환
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("FE"))
        {
            print("소화기 트리거 엑시트 나오나?");
            isFETrigger = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        FEGrab();
    }
}
