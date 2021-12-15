using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("aaa");
            pos.y += 0.1f;
            cnt += 1;
        }
    }

    
}
