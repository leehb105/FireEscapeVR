using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Valve.VR;

public class GameManager : MonoBehaviour
{
    // 싱글턴 생성후 유지
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // 게임매니저는
    // 씬전환
    // 사운드조절
    // 이동방법 설정


    // 현재씬이 무엇인지 저장하는 변수
    private string curScene;

    // 현재 사운드 크기 값을 저장
    private float curVolume;

    // 현재 이동모드를 저장할 변수
    private bool modeTelePort;

    // 텔레포트 버튼
    public Image teleportBtImage;
    // 버튼을 선택할때 버튼의 이미지를 변경
    public Sprite[] teleportChk;


    // 스크롤바 사운드 조절
    public Slider soundSlider;
    // 시작위치와 종료위치를 가지고 거리를 구해서 조절해보자



    // 음소거시 사운드 이미지 변경
    public Image soundImage;
    public Sprite[] soundImageSource;

    // 설정UI의 캔버스
    public Canvas settingUI;
    //설정UI의 캔버스를 가지고있는 게임오브젝트       설정UI를 보여줄때마다 이 오브젝트를 옴기고 빌보드해서 할꺼임
    public GameObject settingUIGameobject;
    // 메뉴를 표시할 위치
    public Transform menu_Position;
    // 설정메뉴가 열렸을때 사운드를 조절하기위해 이동을 막기위한 변수
    private bool openMenu;


    // 마스크 착용상태 체크
    private bool maskCk;
    // 움직일때 숨소리 변경
    private bool moveCk;

    // 스모크에 닿을때 카운트 체크
    private int smokeCount;      // 스모크카운트 누적
  
    // 불을 끈 횟수 체크
    private int extinguishCount;

    // 불에 닿은 횟수 체크
    private int burnCount;
    // 물수건 사용 체크
    private bool wetTowel;

    // 문충돌 횟수 체크
    private int doorCount;

    // 완강기 비디오
    public VideoPlayer wangganggiVideo;
    public MeshRenderer wanMR;
    bool wangganggiCk;

    // 소화기 비디오
    public VideoPlayer sohwajuniVideo;
    public MeshRenderer sohwaMR;
    bool sohwajunCk;

    // 엔드포인트체크
    bool endPoint;

    public SteamVR_Action_Boolean trackPadLeft;
    public SteamVR_Action_Boolean trackPadRight;
    // Start is called before the first frame update
    void Start()
    {
        trackPadLeft = SteamVR_Actions.default_TrackPadLeft;
        trackPadRight = SteamVR_Actions.default_TrackPadDown; 
        //현재씬 상태
        curScene = "start";

        //시작 볼륨값
        curVolume = 100;
        soundSlider.value = curVolume;


        // 텔레포트는 오프모드로 스타트
        modeTelePort = false;
        teleportBtImage.sprite = teleportChk[1];

        // 마스크 상태는 false
        maskCk = false;

        // 움직임 상태는 false;
        moveCk = false;

        // 연기 충돌 카운트 초기화
        smokeCount = 0;

        // 불을 끈 횟수 초기화
        extinguishCount = 0;

        // 불에 닿은 횟수 초기화
        burnCount = 0;

        // 물수건 상태 초기화
        wetTowel = false;

        // 문 충돌 횟수 초기화
        doorCount = 0;

        // 영상시청 체크
        wangganggiCk = false;
        sohwajunCk = false;

        // 종료지점 도착 체크
        endPoint = false;

        //비디오 처음시작시 정지
        wangganggiVideo.playOnAwake = false;
        sohwajuniVideo.playOnAwake = false;
        //비디오 볼륨 세팅
        wangganggiVideo.SetDirectAudioVolume(0, 0.5f);
        sohwajuniVideo.SetDirectAudioVolume(0, 0.1f);
        wanMR.enabled = false;
        sohwaMR.enabled = false;

        //SoundCotroll.instance.soundOff();

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 씬을 바꿀때 호출할 함수
    public void SetScene()
    {

    }

    // 이동방법을 바꿀때 호출할 함수
    public void SetMoveMode()
    {
        if (modeTelePort)
        {
            modeTelePort = false;
            teleportBtImage.sprite = teleportChk[1];
            print("텔레포트끔");
        }
        else
        {
            modeTelePort = true;
            teleportBtImage.sprite = teleportChk[0];
            print("텔레포트 킴");
        }
    }
    // 현재 이동방법을 반환해주는 함수
    public bool GetMoveMode()
    {
        return modeTelePort;
    }

    // 사운드를 조절하는 함수
    // 트리거로 조절할려고 만들었던 함수
    public void SetSound(float volume)
    {
        print("사운드 헤더 트리거로 떙김");
    }



    // 메뉴버튼이 눌리면 호출할 함수
    // 설정창이 꺼져있으면 키고 내앞으로 불러오고 방향맞춰주고
    // 켜져있으면 그냥 캔버스만 끈다.
    public void ShowSettingMenu()
    {
        if (settingUI.enabled == false)
        {
            settingUI.enabled = true;
            openMenu = true;
            //settingUIGameobject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
            settingUIGameobject.transform.position = menu_Position.position;

            settingUIGameobject.transform.forward = Camera.main.transform.forward;

            //settingUIGameobject.transform.rotation = Quaternion.Euler(0, settingUIGameobject.transform.rotation.y, 0);
            //settingUIGameobject.transform.LookAt(Camera.main.transform);
            //settingUIGameobject.transform.rotation = Quaternion.EulerAngles(0, Camera.main.transform.eulerAngles.y, 0);


        }
        else if (settingUI.enabled == true)
        {
            settingUI.enabled = false;
            openMenu = false;
            print("메뉴사라짐");
        }
    }
    // 설정메뉴의 상태를 반환함
    public bool SettingMenuState()
    {
        return openMenu;
    }



    // 마스크 착용상태를 설정하는 함수
    public bool GetMaskState()
    {
        return maskCk;
    }
    public void SetMaskState(bool state)
    {
        maskCk = state;
    }

    // 스모크 처리를 하는 함수
    public void SetSmokeCount()
    {
        smokeCount++;
        print("스모크 카운트  " + smokeCount);
        WarningManager.Instance.SmokeTrigger();


    }
    public int GetSmokeCount()
    {
        return smokeCount;
    }

    // 불을 끈 횟수를 체크하는 함수
    public void SetExtinguishCount()
    {
        extinguishCount++;
        print("불끄기 카운트  " + extinguishCount);
    }
    public int GetExtinguishCount()
    {
        return extinguishCount;
    }

    // 완강기 비디오를 재생
    public void WangganggiVideoPlay()
    {
        //재생중이라면 멈추고 재생중이 아니라면 재생한다.
        if (wangganggiVideo.isPlaying)
        {
            wangganggiVideo.Stop();
            wanMR.enabled = false;
            //SoundCotroll.instance.SoundOnOff(true);
        }
        else
        {
            wanMR.enabled = true;
            //SoundCotroll.instance.SoundOnOff(false);
            wangganggiVideo.Play();
            wangganggiCk = true;
        }
    }

    // 소화기 비디오를 재생
    public void SohwajuniVideoPlay()
    {
        //재생중이라면 멈추고 재생중이 아니라면 재생한다.
        if (sohwajuniVideo.isPlaying)
        {
            sohwajuniVideo.Stop();
            sohwaMR.enabled = false;
            //SoundCotroll.instance.SoundOnOff(true);
        }
        else
        {
            sohwaMR.enabled = true;
            //SoundCotroll.instance.SoundOnOff(false);
            sohwajuniVideo.Play();
            sohwajunCk = true;

        }
    }

    // 불에 닿으면 카운트를 1증가시킴
    public void SetBurnCount()
    {
        burnCount++;
        WarningManager.Instance.FireTrigger();
    }

    public int GetBurnCount()
    {
        return burnCount;
    }

    // 물수건 사용 상태
    public void SetWetTowel(bool state)
    {
        wetTowel = state;
    }
    public bool GetWetTowel()
    {
        return wetTowel;
    }

    // XDoor 닿으면 카운트를 1증가시킴
    public void SetDoorCount()
    {
        doorCount++;
        WarningManager.Instance.DontTouch();

        print(doorCount + "      게임매니져에서 xdoor 카운트");
    }

    public int GetDoorCount()
    {
        return doorCount;
    }

    // 영상을 봤는지 체크
    public bool GetSowhaCK()
    {
        return sohwajunCk;
    }
    public bool GetWangganggiCK()
    {
        return wangganggiCk;
    }

    // 종료지점 체크함수
    public void SetEndPoint()
    {
        endPoint = true;
    }

    public bool GetEndPoint()
    {
        return endPoint;
    }
}
