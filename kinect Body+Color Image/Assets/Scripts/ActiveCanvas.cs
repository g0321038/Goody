using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCanvas : MonoBehaviour
{
    public GameObject Canvas;

    public void OnClick()
    {
        Canvas.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
