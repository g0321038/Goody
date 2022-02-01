using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCanvas : MonoBehaviour
{
    public GameObject TextCanvas;
    public GameObject AnswerCanvas;
    public GameObject FlagCanvas;

    public GameObject QuizCountManager;

    public void OnClick()
    {
        int QuizNum = QuizCountManager.GetComponent<QuizCount>().quiz_num;
        if(QuizNum < 12)
        {
            AnswerCanvas.SetActive(true);
            TextCanvas.SetActive(false);
        }
        else
        {
            FlagCanvas.SetActive(true);
            TextCanvas.SetActive(false);
        }
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
