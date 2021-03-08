using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStart : MonoBehaviour
{
    float time;

    void Update()
    {
        if(time<0.5f)
        {
            GetComponent<TextMesh>().color = new Color(255, 255,255, 1 - time);
        }
        else
        {
            GetComponent<TextMesh>().color = new Color(255, 255,255, time);
            if(time>1f)
            {
                time = 0;
            }
        }
        time += Time.deltaTime;
    }
}
