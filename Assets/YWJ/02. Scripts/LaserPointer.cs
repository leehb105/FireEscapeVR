using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer lr;

    // LineRenderer의 최대 사정거리
    float maxDistance = 5.0f;

    // LineRenderer의 색상
    public Color color = Color.blue;
    public Color ableColor = Color.green;

    private RaycastHit hitInfo;
    private Transform controllerTr;

    // 맞춘위치에 인디케이터를 표시할 오브젝트
    GameObject pointer;
    public GameObject prefabPointer;
    private MeshRenderer pointRenderer;

    public Transform cameraRigTransform;
    public Transform headTransform;



    SteamVR_Action_Boolean trigger;
    SteamVR_Action_Boolean teleport;
    SteamVR_Action_Boolean settingMenu;

    //public GameObject startMenu;

    public Material lineColor;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        trigger = SteamVR_Actions.default_Trigger;
        teleport = SteamVR_Actions.default_TrackPadUp;
        settingMenu = SteamVR_Actions.default_Menu;

        print(teleport);
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        print(pose);
        hand = pose.inputSource;
        controllerTr = GetComponent<Transform>();
        lr = GetComponent<LineRenderer>();
        CreateLineRenderer();

        pointer = Instantiate(prefabPointer);
        pointRenderer = pointer.GetComponent<MeshRenderer>();

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void CreateLineRenderer()
    {
        // LineRenderer생성
        //lr = this.gameObject.AddComponent<LineRenderer>();

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
        //lr.material = new Material(Shader.Find("Unlit/Color"));
        lr.material = lineColor;
       // lr.material.color = this.color;

    }

    // Update is called once per frame
    void Update()
    {
        // 전방방향으로 라인랜더러를 갱신
        if (Physics.Raycast(controllerTr.position, controllerTr.forward, out hitInfo, maxDistance))
        {
            // 맞춘것의 콜라이더의 게임오브젝트의 레이어를
            GameObject hitGameObject = hitInfo.collider.gameObject; //맞춘물체가지고 판별할때 쓸것
            //print("hitGameObject layer: " + hitGameObject.layer);
            lr.SetPosition(1, new Vector3(0, 0, hitInfo.distance));
            // 맞춘게 바닥일때
            if (hitGameObject.layer == LayerMask.NameToLayer("Floor"))
            {
                lr.material.color = ableColor;
                // 텔레포트 모드일때만
                if (GameManager.instance.GetMoveMode())
                {
                    pointRenderer.enabled = true;
                }
                // 히트포인트의 포인터에 인디케이터 표시
                pointer.transform.position = hitInfo.point + (hitInfo.normal * 0.01f);
                pointer.transform.rotation = Quaternion.LookRotation(hitInfo.normal);

                // 텔레포트모드일때만 위쪽 방향키로 해당위치를 이동
                if (GameManager.instance.GetMoveMode())
                {
                    // 트랙패드의 위쪽 방향키를 누르면 해당위치로 이동
                    if (teleport.GetStateDown(hand))
                    {
                        if (hitGameObject.layer == LayerMask.NameToLayer("Floor"))
                        {
                            // 키가 다운됬을때 코루틴 호출
                            StartCoroutine(this.Teleport(hitInfo.point));
                        }
                    }
                }
                
            }
            
            // 맞춘게 텔레포트의 체크박스일때
            else if (hitGameObject.tag.Contains("TeleportCk"))
            {
                lr.material.color = ableColor;
                
              
                // 트리거버튼이 눌리면
                if (trigger.GetStateDown(hand))
                {
                    audioSource.Play();
                    // 게임매니저에 함수 불러오기
                    GameManager.instance.SetMoveMode();
                }

            }
            // 완강기를 맞추고 트리거를 당기면 동영상을 재생
            else if (hitGameObject.tag.Contains("Wangganggi"))
            {
                lr.material.color = ableColor;
                if (SteamVR_Actions.default_Trigger.GetStateDown(hand))
                {
                    audioSource.Play();
                    GameManager.instance.WangganggiVideoPlay();
                }
            }
            else if (hitGameObject.tag.Contains("Sohwajun"))
            {
                lr.material.color = ableColor;
                if (SteamVR_Actions.default_Trigger.GetStateDown(hand))
                {
                    audioSource.Play();
                    GameManager.instance.SohwajuniVideoPlay();
                }
            }
            else if (hitGameObject.tag.Contains("Home"))
            {
                lr.material.color = ableColor;
                if (SteamVR_Actions.default_Trigger.GetStateDown(hand))
                {
                    SceneManager.LoadScene(0);
                }
            }
            // 그외 것들을 맞출때 색을 기본색으로
            else
            {
                lr.material.color = color;
                pointRenderer.enabled = false;
            }

        }

        if (settingMenu.GetStateDown(hand)){
            audioSource.Play();
            MenuBt();
        }
    }

    // 이동을 연속으로 하는걸 막기위해 방지
    IEnumerator Teleport(Vector3 pos)
    {
        // 텔레포트한곳에서 살짝위로 이동
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;

        cameraRigTransform.position = pos+difference;
        yield return new WaitForSeconds(0.1f);
    }

    public void MenuBt()
    {
        GameManager.instance.ShowSettingMenu();
    }
}
