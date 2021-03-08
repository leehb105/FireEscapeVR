using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PinGrab : MonoBehaviour
{
    public bool pinState;//true: 핀 있는 상태  false: 핀 없는 상태
    GameObject pin;

    public static PinGrab instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pinState = true;//핀 있는 상태
    }
    private void OnTriggerStay(Collider other)
    {
        if (SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if (other.gameObject.tag.Contains("Pin"))
            {
                if (pin == null)
                {
                    pin = other.gameObject;
                }
                pinState = false;//핀 없음
                print("핀 충돌함");
                //부모자식 해제
                other.transform.parent = null;
                FEState.instance.setState(2);
            }            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!pinState)//핀이 없으면
        {
            if (pin != null)
            {
                pin.transform.position = transform.position;
            }
            if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                print("잡은상태에서 다시 놓았음");
                Destroy(pin);
            }
        }
    }
}
