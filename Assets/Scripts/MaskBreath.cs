using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBreath : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips; //0:slow, 1: fast
    public MeshRenderer camMask;
    public GameObject maskText;
    public MeshRenderer towel;
    // Start is called before the first frame update
    void Start()
    {
        maskText.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];//디폴트 slow
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        camMask.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //마스크가 카메라에 충돌하면 느린버전 음원 재생
        if (other.gameObject.tag.Contains("Mask"))
        {
            audioSource.Play();
            towel.enabled = false;
            camMask.enabled = true;
            maskText.SetActive(true);
            //2초후에 마스크 착용텍스트 오프
            Invoke("maskTextOff", 2);
            // 마스크 쓴 상태로 설정
            GameManager.instance.SetMaskState(true);
            
        }
    }
    public void maskTextOff()
    {
        maskText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
