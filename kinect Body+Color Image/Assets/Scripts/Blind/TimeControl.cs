using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public GameObject TextObj;

    public GameObject QuizPanel_Canvas;

    private Text CountText;

    private int LimitTime;//制限時間

    public float ProgressTime=0;

    public GameObject BlindGamePanel;

    public GameObject QuestionPanel;

    public GameObject SelectAnswer;
    
    // Start is called before the first frame update
    void Start()
    {
        LimitTime = 10;

        CountText = TextObj.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTime += Time.deltaTime;

        string TimeText = (LimitTime-ProgressTime).ToString("00");

        CountText.text = TimeText;

        if(ProgressTime>LimitTime)
        {
            switchActive();
        }
    }

    private void switchActive()/*アクティブ状態の切り替え*/
    {
        ProgressTime = 0;

        //BlindGamePanel.SetActive(false);

        //QuestionPanel.SetActive(true);
        QuizPanel_Canvas.SetActive(false);

        SelectAnswer.SetActive(true);
    }

}
