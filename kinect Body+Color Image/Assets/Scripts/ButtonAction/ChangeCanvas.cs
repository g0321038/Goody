using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCanvas : MonoBehaviour
{
    public GameObject now_canvas;
    public GameObject next_canvas;

    public void OnClick()
    {
        next_canvas.SetActive(true);
        now_canvas.SetActive(false);
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
