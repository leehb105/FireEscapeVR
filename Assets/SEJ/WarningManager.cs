using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using TMPro;
public class WarningManager : MonoBehaviour
{
    public static WarningManager Instance;
    private void Awake()
    {
        Instance = this;
    }


    //경고창 이미지
    public Image warningImage;
    public TextMeshProUGUI warningText;
    //경고창 이미지 배열
    public Sprite[] sprite;

    void Start()
    {
        warningImage.enabled = false;
        warningText.enabled = false;
    }

    public void SmokeTrigger()
    {
        //crawl 이미지 , smoke와 충돌 시 
        warningImage.enabled = true;
        warningImage.sprite = sprite[0];
        warningText.enabled = true;
        Invoke("OffImage", 2);
    }

    public void OffImage()
    {
        warningImage.enabled = false; 
        warningText.enabled = false;
    }

    public void DontTouch()
    {
        //door 이미지 , 문과 충돌 시 
        warningImage.enabled = true;
        warningText.enabled = true;
        warningImage.sprite = sprite[1];
        Invoke("OffImage", 2);
    }

    public void FireTrigger()
    {
        //Fire 이미지 , 불과 충돌 시 
        warningImage.enabled = true;
        warningText.enabled = true;
        warningImage.sprite = sprite[2];
        Invoke("OffImage", 2);
    }

}


