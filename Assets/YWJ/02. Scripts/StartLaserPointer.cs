using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class StartLaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer lr;

    // LineRenderer의 최대 사정거리
    float maxDistance = 10f;

    // LineRenderer의 색상
    public Color color = Color.blue;
    public Color ableColor = Color.green;

    private RaycastHit hitInfo;
    private Transform tr;

    public Material lineColor;

    SteamVR_Action_Boolean trigger;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        trigger = SteamVR_Actions.default_Trigger;
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;

        CreateLineRenderer();

        tr = GetComponent<Transform>();

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        
    }

    void CreateLineRenderer()
    {
        // LineRenderer생성
        //lr = this.gameObject.AddComponent<LineRenderer>();
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.receiveShadows = false;

        // 시작점과 끝점의 위치 설정
        lr.positionCount = 2;
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, new Vector3(0, 0, maxDistance));

        // LineRenderer 너비 설정
        lr.startWidth = 0.03f;
        lr.endWidth = 0.005f;

        // LineRenderer의 머티리얼 및 색상 설정
        lr.material = new Material(Shader.Find("Unlit/Color"));
        lr.material.color = this.color;
    }

    // Update is called once per frame
    void Update()
    {
        BtnClickSound();
        if (Physics.Raycast(tr.position, tr.forward, out hitInfo, maxDistance))
        {
            // 맞춘것의 콜라이더의 게임오브젝트의 레이어를
            GameObject hitGameObject = hitInfo.collider.gameObject; //맞춘물체가지고 판별할때 쓸것
            //print("hitGameObject layer: " + hitGameObject.layer);
            lr.SetPosition(1, new Vector3(0, 0, hitInfo.distance));

            if (hitGameObject.tag.Contains("StartBtn"))
            {
                lr.material.color = ableColor;
                if (SteamVR_Actions.default_Trigger.GetStateDown(hand))
                {
                    SceneManager.LoadScene("MainScene");
                    //startMenu.SetActive(false);
                    //SoundCotroll.instance.soundOn();
                    //SoundCotroll.instance.fireBroadcast.Play();
                    //SoundCotroll.instance.fireAlarm.Play();
                }
            }
            else if (hitGameObject.tag.Contains("ExitBtn"))
            {
                lr.material.color = ableColor;
                if (SteamVR_Actions.default_Trigger.GetStateDown(hand))
                {
                    Application.Quit();
                }
            }
            else
            {
                lr.material.color = color;

            }
        }
    }
    public void BtnClickSound()
    {
        if (SteamVR_Actions.default_Trigger.GetStateDown(hand))
        {
            audioSource.Play();
        }
    }
}
