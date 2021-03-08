using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject[] lights;

    float currentTime;
    float onTime = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > onTime)
        {
            currentTime = 0;
            for (int i = 0; i < lights.Length; i++)
            {
                if(lights[i].activeSelf)
                {
                    lights[i].SetActive(false);
                }
                else
                {
                    lights[i].SetActive(true);
                }
            }

        }
    }
}
