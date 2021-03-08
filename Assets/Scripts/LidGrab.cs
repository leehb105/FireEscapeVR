using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LidGrab : MonoBehaviour
{
    GameObject lid;
    bool lidState;
    // Start is called before the first frame update
    void Start()
    {
        lidState = true;//뚜껑이 병에 있는 상태
    }
    private void OnTriggerStay(Collider other)
    {
        if (SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if (other.gameObject.tag.Contains("WaterBLid"))
            {
                if (lid == null)
                {
                    lid = other.gameObject;//뚜껑에 넣어줌
                }
                lidState = false;//뚜껑 없음
                print("뚜껑 충돌함");
                other.transform.parent = transform;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!lidState)//뚜껑이 없으면
        {
            if (lid != null)
            {
                lid.transform.position = transform.position;
            }
            if (SteamVR_Actions.default_GrabGrip.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                print("잡은상태에서 다시 놓았음");
                WaterBottle.instance.isLid = false;
                Destroy(lid);
            }
        }
    }
}
