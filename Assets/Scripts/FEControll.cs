using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class FEControll : MonoBehaviour
{
    //SteamVR_Behaviour_Pose pose;
    //SteamVR_Input_Sources rHand;
    public GameObject particleFactory;
    public GameObject feCubeFactory;
    public GameObject firePosition;
    AudioSource audioSource;
    float shotCurTime;
    float partCurTime;
    float partTime = 0.05f;
    float shotTime = 0.05f;
    FECube fc;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.volume = 0.5f;
        partCurTime = partTime;
        shotCurTime = shotTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(FEState.instance.getState() == 2)
        {
            print(FEState.instance.getState() + "getState()상태");
            if (SteamVR_Actions.default_Trigger.GetState(SteamVR_Input_Sources.RightHand))
            {
                //연기 파티클
                partCurTime += Time.deltaTime;
                if (partCurTime > partTime)
                {
                    partCurTime = 0;
                    print("오른쪽 눌렀는데 재생되나?");
                    GameObject particle = Instantiate(particleFactory);
                    particle.transform.position = firePosition.transform.position;
                    //particle.transform.position = transform.position+(transform.forward*0.1f) + (transform.up * 0.1f);
                    particle.transform.forward = transform.forward;
                    //audioSource.Play();
                    Destroy(particle, 3);
                }
                //큐브
                shotCurTime += Time.deltaTime;
                if(shotCurTime > shotTime)
                {
                    shotCurTime = 0;
                    GameObject feCube = Instantiate(feCubeFactory);
                    feCube.transform.position = firePosition.transform.position;
                    fc = feCube.GetComponent<FECube>();
                    fc.CubeCheck();
                    feCube.transform.forward = transform.forward;

                }
            }
            if (SteamVR_Actions.default_Trigger.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                audioSource.Play();
               
            }
            if (SteamVR_Actions.default_Trigger.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                shotCurTime = shotTime;
                audioSource.Stop();
            }


        }
    }
    
}
