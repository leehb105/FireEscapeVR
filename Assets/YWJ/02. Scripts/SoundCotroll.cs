using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;

public class SoundCotroll : MonoBehaviour
{
    // 오디오믹서
    public AudioMixer am;

    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;

    SteamVR_Action_Boolean left;
    SteamVR_Action_Boolean right;

    public Slider soundSl;

    public AudioSource fireBroadcast;
    public AudioSource fireAlarm;



    public static SoundCotroll instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;

        left = SteamVR_Actions.default_TrackPadLeft;
        right = SteamVR_Actions.default_TrackPadRight;

        fireBroadcast.Stop();
        fireBroadcast.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (GameManager.instance.SettingMenuState())
            {
                if (left.GetState(hand))
                {
                    soundSl.value--;
                    if (soundSl.value <= -40)
                    {
                        am.SetFloat("Master", -80);
                        am.SetFloat("Fire", -80);
                    }
                    else
                    {
                        am.SetFloat("Master", soundSl.value);
                        am.SetFloat("Fire", soundSl.value);
                    }
                }
                else if (right.GetState(hand))
                {
                    soundSl.value++;
                    if (soundSl.value >= 0)
                    {
                        am.SetFloat("Master", 0);
                        am.SetFloat("Fire", 0);
                    }
                    else
                    {
                        am.SetFloat("Master", soundSl.value);
                        am.SetFloat("Fire", soundSl.value);
                    }
                }

            }
        }

    }

    //public void soundOff()
    //{
    //    am.SetFloat("Master", -80);
    //    am.SetFloat("Fire", -80);

    //}

    //public void soundOn()
    //{
    //    am.SetFloat("Master", 0);
    //    am.SetFloat("Fire", 0);
    //}
    /*public void SoundOnOff(bool state)
    {
        //true: on
        //false: off
        if(state == true)
        {
            am.SetFloat("Master", -80);//음소거
        }
        else if(state == false)
        {

        }
    }*/
}
