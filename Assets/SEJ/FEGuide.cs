using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEGuide : MonoBehaviour
{
    public GameObject guide;
    private void Start()
    {
        guide.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
            guide.SetActive(true);
    }
}
