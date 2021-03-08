using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraStartPosition : MonoBehaviour
{
    public GameObject startPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            transform.position = startPoint.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
