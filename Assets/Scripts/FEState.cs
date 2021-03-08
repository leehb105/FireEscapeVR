using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEState : MonoBehaviour
{
    public static FEState instance;
    float gravity = 5f;
    private void Awake()
    {
        //instance = this;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            gravity = 0;
            
        }
    }
    //이넘을 못가져오는 이유로 다른 방법으로 섰다 앉앗다를 관리 해야 할거 같음 그러니까 내일 하자!
    public enum State
    {
        Default,
        Grabed,
        NoPin
    }
    public int getState()
    {
        if(state == State.Default)
        {
            return 0;
        }else if(state == State.Grabed)
        {
            return 1;
        }else if(state == State.NoPin)
        {
            return 2;
        }
        return 100;

    }
    public void setState(int i)
    {
        if(i == 0)
        {
            state = State.Default;
            gravity = 5f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(i == 1)
        {
            state = State.Grabed;
            gravity = 0;
        }else if(i == 2)
        {
            state = State.NoPin;
            gravity = 0;
        }
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Default;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * gravity * Time.deltaTime;
    }
}
