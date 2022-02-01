using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountyFlagChange : MonoBehaviour
{
    public GameObject QuizCountManager;

    public GameObject CountyFlag;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int QuizNum = QuizCountManager.GetComponent<QuizCount>().quiz_num;
        switch(QuizNum)
        {
            case 12:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/JapanFlag");
                break;
            case 13:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/HawaiFlag");
                break;
            case 14:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/ThailandFlag");
                break;
            case 15:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/ZimbabweFlag");
                break;
            case 16:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/ChinaFlag");
                break;
            case 17:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/AmericaFlag");
                break;
            case 18:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/CanadaFlag");
                break;
            case 19:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/EgyptFlag");
                break;
            case 20:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/EnglandFlag");
                break;
            case 21:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/SpainFlag");
                break;
            case 22:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/BrazilFlag");
                break;
            case 23:
                CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/FranceFlag");
                break;
        }
        //if(QuizNum == 12 || QuizNum == 16 || QuizNum == 20)
        //{
        //    CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/JapanFlag");
        //}
        //else if(QuizNum == 13 || QuizNum == 17 || QuizNum == 21)
        //{
        //    CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/HawaiFlag");
        //}
        //else if(QuizNum == 14 || QuizNum == 18 || QuizNum == 22)
        //{
        //    CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/ThailandFlag");
        //}
        //else if(QuizNum == 15 || QuizNum == 19 || QuizNum == 23)
        //{
        //    CountyFlag.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/ZimbabweFlag");
        //}
    }
}
