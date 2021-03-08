using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    //public List<ParticleSystem> partList;
    ParticleSystem ps;
    public GameObject text;
    int fireHP = 30;
    public int FireHP
    {
        get {
            return fireHP;
        }
        set {
            fireHP -= value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        ps = GetComponent<ParticleSystem>();
    }
    public void Emission()
    {
        var em = ps.emission;
        em.rateOverTime = FireHP/2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("ShotCube"))
        {
            FireHP = 1;
            if(FireHP == 20)
            {
                Emission();
            }           
            else if(FireHP == 10)
            {
                Emission();
            }
            else if(FireHP == 0)
            {
                ps.Stop();
                Invoke("TextOn", 1.5f);
                Invoke("TextOFF", 3);
                //Destroy(gameObject);

                GameManager.instance.SetExtinguishCount();
            }
        }
    }
    public void TextOn()
    {
        text.SetActive(true);
    }

    public void TextOFF()
    {
        text.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        
    }
}
