using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FECube : MonoBehaviour
{

    //본 큐브 불에만 닿도록 레이어 처리 필요
    public float speed = 2;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(check == true)
        {
            print("큐브 쏴지나?");
            Vector3 dir = transform.forward;
            transform.position += dir * speed * Time.deltaTime;
        }
        
    }
    public void CubeCheck()
    {
        check = true;
    }
}
