using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLight : MonoBehaviour
{
    public GameObject light1, light2, light3;
    
    float currentTime;
    float onTime = 1;
    float offTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        if (currentTime > onTime)
        {
            //print("켜졌냐");
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);

        }
        if (currentTime > offTime)
        {
            //print("꺼졌냐");
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
            currentTime = 0;
        }

    }
}
