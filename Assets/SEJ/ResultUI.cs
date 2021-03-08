using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultUI : MonoBehaviour
{

    public GameObject firework;
    public TextMeshProUGUI textTitle;
    bool titleCk;
    public TextMeshProUGUI textMask;
    bool maskCk;
    public TextMeshProUGUI textDoor;
    bool doorCk;
    public TextMeshProUGUI textVideo;
    bool videoCk;
    public TextMeshProUGUI textBurn;
    bool burnCk;
    public TextMeshProUGUI textToxic;
    bool toxicCk;
    public Canvas resultCancvas;
    float totalScore;

    void Start()
    {
        firework.SetActive(false);
        resultCancvas.enabled = false;
        totalScore = 0;
    }
    public void EffectOn()
    {
        //성공이펙트 발생
        firework.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (resultCancvas.isActiveAndEnabled)
        {
            Invoke("EffectOn", .2f);
            if (!maskCk)
            {
                //마스크를 썼을 때&&손수건 사용
                if (GameManager.instance.GetMaskState() && GameManager.instance.GetWetTowel())//true자리에 손수건 체크 넣을 것
                {
                    totalScore += 10;
                    textMask.text = "S";
                }
                //마스크만 썼을 때
                else if (GameManager.instance.GetMaskState())
                {
                    totalScore += 8;
                    textMask.text = "A";
                }
                //손수건만 사용했을 때
                else if (GameManager.instance.GetWetTowel())//true자리에 손수건 체크내용 작성
                {
                    totalScore += 6;
                    textMask.text = "B";
                }
                //둘 다 사용하지 않을 때
                else
                {
                    totalScore += 4;
                    textMask.text = "C";
                }
                maskCk = true;
            }
            if (!doorCk)
            {
                //문 
                if (GameManager.instance.GetDoorCount() < 2)
                {
                    totalScore += 10;
                    textDoor.text = "S";
                }
                else if (GameManager.instance.GetDoorCount() < 4)
                {
                    totalScore += 8;
                    textDoor.text = "A";
                }
                else if (GameManager.instance.GetDoorCount() < 6)
                {
                    totalScore += 6;
                    textDoor.text = "B";
                }
                else
                {
                    totalScore += 4;
                    textDoor.text = "C";
                }
                doorCk = true;
            }

            if (!toxicCk)
            {

                //연기
                if (GameManager.instance.GetSmokeCount() < 2)
                {
                    totalScore += 10;
                    textToxic.text = "S";
                }
                else if (GameManager.instance.GetSmokeCount() < 4)
                {
                    totalScore += 8;
                    textToxic.text = "A";
                }
                else if (GameManager.instance.GetSmokeCount() < 6)
                {
                    totalScore += 6;
                    textToxic.text = "B";
                }
                else
                {
                    totalScore += 4;
                    textToxic.text = "C";
                }
                toxicCk = true;
            }

            if (!videoCk)
            {

                //동영상 체크 자리
                if (GameManager.instance.GetWangganggiCK() && GameManager.instance.GetSowhaCK())
                {
                    totalScore += 10;
                    textVideo.text = "S";
                }
                else if (GameManager.instance.GetWangganggiCK())
                {
                    totalScore += 8;
                    textVideo.text = "A";
                }
                else if (GameManager.instance.GetSowhaCK())
                {
                    totalScore += 6;
                    textVideo.text = "B";
                }
                else
                {
                    totalScore += 4;
                    textVideo.text = "C";
                }
                videoCk = true;
            }

            if (!burnCk)
            {

                // 화상체크
                if (GameManager.instance.GetBurnCount() < 2)
                {
                    totalScore += 10;
                    textBurn.text = "S";
                }
                else if (GameManager.instance.GetBurnCount() < 4)
                {
                    totalScore += 8;
                    textBurn.text = "A";
                }
                else if (GameManager.instance.GetBurnCount() < 6)
                {
                    totalScore += 6;
                    textBurn.text = "B";
                }
                else
                {
                    totalScore += 4;
                    textBurn.text = "C";
                }
                burnCk = true;
            }
            if (!titleCk)
            {
                print(totalScore + "      토탈스코어");
                if ((totalScore / 5) > 8)
                {
                    textTitle.text = "당신은 생존왕";
                }
                else if ((totalScore / 5) > 6)
                {
                    textTitle.text = "당신은 탈출왕";
                }
                else if ((totalScore / 5) > 4)
                {
                    textTitle.text = "아쉽지만 재도전";
                }
                else
                {
                    textTitle.text = "최악이에요";
                }
                titleCk = true;
            }
        }

    }
}
