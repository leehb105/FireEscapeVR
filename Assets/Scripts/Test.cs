using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        print("other의 이름: " + other.gameObject.name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
