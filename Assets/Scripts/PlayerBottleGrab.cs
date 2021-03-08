using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerBottleGrab : MonoBehaviour
{
    bool isBottleGrab;
    GameObject bottle;
    public GameObject grabPoint;
    //public GameObject bottleGrabPoint;
    // Start is called before the first frame update
    void Start()
    {
        isBottleGrab = false;
        bottle = GameObject.Find("WaterB");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("WaterB"))
        {
            isBottleGrab = true;
        }
    }
    public void BottleGrab()
    {
        if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (isBottleGrab)
            {
                //bottle = GameObject.FindGameObjectWithTag("WaterB").gameObject;
                print("물병 트리거 작동");
                //grabPoint.transform.position = transform.position;
                transform.position = grabPoint.transform.position;
                bottle.transform.parent = transform;
                //bottle.transform.localEulerAngles = new Vector3(80, transform.rotation.y, transform.rotation.z);
                bottle.transform.localEulerAngles = new Vector3(transform.rotation.x, 200, transform.rotation.z);
                isBottleGrab = false;


            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        BottleGrab();
        if (WaterBottle.instance.bottleDestroy)
        {
            //Destroy(bottle, 1);
            bottle.gameObject.SetActive(false);
        }
    }
}
