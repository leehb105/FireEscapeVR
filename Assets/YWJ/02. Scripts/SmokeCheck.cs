using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCheck : MonoBehaviour
{
    bool isTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //연기에 충돌한게 메인카메라라면 카운트++한다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("MainCamera"))
        {
            if (!isTrigger)
            {
                Debug.Log("메인카메라와 스모크와 충돌함");
                GameManager.instance.SetSmokeCount();
                isTrigger = true;
            }
        }
    }
    //테스트용 트리거아웃
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("MainCamera"))
        {
            Debug.Log("연기와 충돌 끝");
            isTrigger = false;

        }
    }
}
