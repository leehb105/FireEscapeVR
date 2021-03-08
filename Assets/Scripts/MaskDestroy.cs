using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //메인카메라에 닿으면 나(마스크)삭제
        if (other.gameObject.tag.Contains("MainCamera"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
