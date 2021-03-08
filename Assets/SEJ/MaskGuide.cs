using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskGuide : MonoBehaviour
{
    public GameObject maskGuide;
    
    void Start()
    {
        maskGuide.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Controller"))
        {
            maskGuide.SetActive(true);
        }
    }
    
}
