using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel : MonoBehaviour
{
    public Material mat;
    public static Towel instance;
    public bool grabTowel = false;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //뚜껑이 없어졌으면
        if(WaterBottle.instance.isLid == false)
        {
            //트리거가 물병이면
            if (other.gameObject.CompareTag("WaterPoint"))
            {
                print("물에 젖어라");
                WaterBottle.instance.ispart = true;
                Invoke("TowerWet", 1);//물따르고 1초있다가 젖은효과
                grabTowel = true;
            }
        }
        
    }
    public void TowerWet()
    {
        Renderer renderer = GetComponent<MeshRenderer>();
        renderer.material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
