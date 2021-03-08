using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControll : MonoBehaviour
{
    public GameObject rotPos;
    bool doorState = false; //0:닫힘, 1:열림
    bool isTouch = true;
    Quaternion originRot;
    float speed = 2;
    // Start is called before the first frame update

    AudioSource openSound;


    Transform temp;
    void Start()
    {
        originRot = rotPos.transform.rotation;//초기 회전값 기억
        temp = transform.parent;
        print(temp.gameObject.name);
        openSound = GetComponent<AudioSource>();
        openSound.playOnAwake = false;
        openSound.loop = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (isTouch)
        {
            if (other.gameObject.name.Contains("Controller"))
            {
                openSound.Play();
                Invoke("WaitAMinute", 1);
                print("문이 터치 됐는가");
                if (!doorState)
                {
                    print("1.러프가 도는가");
                    doorState = true;
                }
                else if (doorState)
                {
                    print("2.러프가 도는가");
                    doorState = false;
                }
                isTouch = false;

                //while (temp != null)
                //{
                //    if (temp.parent == null)
                //    {
                //        break;
                //    }
                //    temp = temp.parent;
                //    print(temp.gameObject.name + "   문의 이름");
                //    print(temp.gameObject.tag + "   문의 tag");
                //}
                //if (temp.gameObject.tag == "XDoor")
                //{
                //    GameManager.instance.SetDoorCount();

                //}
                if (gameObject.tag == "XDoor")
                {
                    GameManager.instance.SetDoorCount();
                }
            }



        }
    }
    public void WaitAMinute()
    {
        isTouch = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!doorState)//문이 닫혔음
        {
            rotPos.transform.localRotation = Quaternion.Lerp(transform.rotation, originRot, Time.deltaTime * speed);

        }
        else if (doorState)//문이 열렸음
        {
            rotPos.transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 30, 0), Time.deltaTime * speed);
        }
    }
}
