using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Title : MonoBehaviour
{
    public float Limit_Time;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= Limit_Time)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
