using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTowel : MonoBehaviour
{
    public MeshRenderer camTowel;
    public GameObject towelText;
    // Start is called before the first frame update
    void Start()
    {
        towelText.SetActive(false);
        camTowel.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Towel"))
        {
            camTowel.enabled = true;
            print("손수건나타남");
            towelText.SetActive(true);
            print("손수건글시 나타남");
            //2초후에 마스크 착용텍스트 오프
            Invoke("TowelTextOff", 2);
            // 마스크 쓴 상태로 설정
            GameManager.instance.SetWetTowel(true);

        }
    }
    public void TowelTextOff()
    {
        towelText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
