using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Answer�ɏ����ꂽ���e���琳���̔��������
��̃I�u�W�F�N�g�ɃA�^�b�`
 */
public class JudgeText : MonoBehaviour
{

    public GameObject AnswerObj;

    public GameObject now_canvas;
    public GameObject next_canvas;

    private Text AnswerText;

    private int WordCount;

    public int CountryNum;

    public int AnswerCount = 0;

    public int AnsweredFlag = 0;

    private int SceneMoveFlag = 0;

    private float SceneMoveDelay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        AnswerText = AnswerObj.GetComponent<Text>();
        /*�����̃f�[�^�����炩���߃��[�h*/

        CountryNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WordCount = AnswerText.text.Length; WordCount = AnswerText.text.Length;
        Debug.Log(WordCount);
        switch (CountryNum)
        {
            case 0://���{�i�f�o�b�O�p�j
                if (WordCount == 5)//JAPAN��5����
                {
                    if (AnswerText.text == "JAPAN")//���𔻒�
                    {
                        AnswerText.text = "Collect!!!";
                        Debug.Log("Collect!!!");
                        SceneMoveFlag = 1;
                    }
                    else
                    {
                        AnswerText.text = "Failed...";

                        Debug.Log("Failed");
                    }
                    AnsweredFlag = 1;
                    AnswerCount += 1;//�񓚂̉񐔁i����t���̉񐔁j
                }
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;


        }

        if (AnswerCount == 3)//����t���O��Ŏ��̃V�[���ɑJ��
        {
            SceneMoveFlag = 1;
        }

        if (SceneMoveFlag == 1)
        {
            SceneMoveDelay += Time.deltaTime;
            if (SceneMoveDelay > 1.0f)
            {
                Quiz2Movie();
            }

        }


    }
    void Quiz2Movie()
    {
        //SceneManager.LoadScene("result");
        
        next_canvas.SetActive(true);
        now_canvas.SetActive(false);
    }
}
