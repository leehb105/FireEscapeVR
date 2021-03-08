using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class PlayerTowerGrab : MonoBehaviour
{
    bool iTowelGrab;
    GameObject towel;
    public GameObject towelGrabPoint;
    // Start is called before the first frame update
    void Start()
    {
        iTowelGrab = false;
    }
    // Update is called once per frame
    void Update()
    {
        TowelGrab();
    }
    //마스크에 닿았으면 상태 트루 전환
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Towel"))
        {
            print("마스크 트리거 엔터 들어오나");
            iTowelGrab = true;
        }
    }
    //마스크에 안 닿았으면 상태 false 전환
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("Towel"))
        {
            print("마스크 트리거 엑시트 들어오나");
            iTowelGrab = false;
        }
    }
    public void TowelGrab()
    {
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            if (Towel.instance.grabTowel)
            {
                if (SteamVR_Actions.default_GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand))
                {
                    if (iTowelGrab)
                    {
                        towel = GameObject.FindGameObjectWithTag("Towel").gameObject;
                        print("손수건 트리거 작동");
                        transform.position = towelGrabPoint.transform.position;
                        towel.transform.parent = transform;
                        towel.transform.localEulerAngles = new Vector3(45, transform.rotation.y, transform.rotation.z);
                        iTowelGrab = false;
                    }
                }
            }
        }
    }
}