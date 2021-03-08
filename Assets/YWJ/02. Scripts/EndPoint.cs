using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    public Canvas resultUI;
    public Canvas restartUI;
    bool resultCk;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.8f;
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name + "    엔드포인트와 충돌했음");
        if (other.gameObject.tag == "MainCamera"&&!resultCk)
        {
            audioSource.Play();
            resultUI.enabled = true;
            restartUI.enabled = true;
            resultCk = true;
        }
    }

}
