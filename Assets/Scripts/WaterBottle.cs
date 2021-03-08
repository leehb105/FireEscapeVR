using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    public static WaterBottle instance;
    private void Awake()
    {
        instance = this;
    }

    public bool isLid = true;
    public bool ispart = false;
    public bool bottleDestroy = false;
    public GameObject partFactory;
    public GameObject waterPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ispart)
        {
            GameObject part = Instantiate(partFactory);
            part.transform.position = waterPoint.transform.position;
            Destroy(part, 2);
            ispart = false;
            bottleDestroy = true;
            
        }
    }
}
