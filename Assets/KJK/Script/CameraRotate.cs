using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotSpeed = 200;
    float anglex;
    float angley;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// 1. 마우스를 입력값을 이용해서 
        //float mx = Input.GetAxis("Mouse X");
        //float my = Input.GetAxis("Mouse Y");
        ////print(mx + ", " + my);
        //anglex += my * rotSpeed * Time.deltaTime;
        //angley += mx * rotSpeed * Time.deltaTime;
        //// anglex 각도를 제약하고싶다.
        //anglex = Mathf.Clamp(anglex, -45, 45);
        //// 2. 회전값을 만들고
        //Vector3 angle = new Vector3(-anglex, angley, 0);
        //// 3. 그 회전값으로 카메라를 회전하고싶다.
        //transform.eulerAngles = angle;
        transform.forward = Camera.main.transform.forward;
        
    }
}
