using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FootStep : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_TrackPadUp.GetState(SteamVR_Input_Sources.LeftHand) || SteamVR_Actions.default_TrackPadDown.GetState(SteamVR_Input_Sources.LeftHand) || SteamVR_Actions.default_TrackPadRight.GetState(SteamVR_Input_Sources.LeftHand) || SteamVR_Actions.default_TrackPadLeft.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if(audioSource.isPlaying == false)
            {
                audioSource.Play();

            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }
}
