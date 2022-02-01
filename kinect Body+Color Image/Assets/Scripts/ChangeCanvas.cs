using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCanvas : MonoBehaviour
{
    public GameObject now_canvas;
    public GameObject next_canvas;
    //public GameObject blind_canvas;

    //private int QuizNum;

    public void OnClick()
    {
        //if(QuizNum < 12)
        //{
        //    next_canvas.SetActive(true);
        //    now_canvas.SetActive(false);
        //}
        //else
        //{
        //    blind_canvas.SetActive(true);
        //    now_canvas.SetActive(false);
        //}
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
        //GameObject QuizCountManager = GameObject.Find("QuizCountManager");
        //QuizNum = QuizCountManager.GetComponent<QuizCount>().quiz_num;
    }
}
