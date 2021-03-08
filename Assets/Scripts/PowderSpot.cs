using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderSpot : MonoBehaviour
{
    public GameObject stainFactory;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("FECube"))
        {
            GameObject stain = Instantiate(stainFactory);
            stain.transform.position = other.transform.position;
            Destroy(stain, 10);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
