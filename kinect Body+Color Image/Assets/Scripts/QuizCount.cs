using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class QuizCount : MonoBehaviour
{
    public int count; //�N�C�Y�̏o�肵�����̃J�E���g

    public int quiz_num; //�N�C�Y�̔ԍ�

    public int correct_count; //�N�C�Y���𐔃J�E���g

    public int QuizMax;

    public GameObject TextQuestionNum;

    public GameObject TextQuestion;

    public GameObject TextJudgeManager;

    private TextAsset csvFile_QuestionNum; //csvfile

    private TextAsset csvFile_Question; //csvfile

    private List<string[]> csvDatas_QuestionNum = new List<string[]>(); //csv�̒��g�����郊�X�g
    
    private List<string[]> csvDatas_Question = new List<string[]>(); //csv�̒��g�����郊�X�g

    private List<int> random = new List<int>(); //�����_���p���X�g

    private int QuestionMax; //�N�C�Y�̐�

    // Start is called before the first frame update
    void Start()
    {
        //csvFile�Ƃ��ēǂݍ���
        csvFile_Question = Resources.Load("Texts/Quiz/Quiz1/QuestionText") as TextAsset;
        csvFile_QuestionNum = Resources.Load("Texts/Quiz/Quiz1/QuestionNumText") as TextAsset;
        
        StringReader reader_Question = new StringReader(csvFile_Question.text);
        StringReader reader_QuestionNum = new StringReader(csvFile_QuestionNum.text);

        while (reader_Question.Peek() != -1)
        {
            string line = reader_Question.ReadLine(); //��s���ǂݍ���
            csvDatas_Question.Add(line.Split(',')); //,��؂�Ń��X�g�ɒǉ�
        }

        while (reader_QuestionNum.Peek() != -1)
        {
            string line = reader_QuestionNum.ReadLine(); //��s���ǂݍ���
            csvDatas_QuestionNum.Add(line.Split(',')); //,��؂�Ń��X�g�ɒǉ�
        }

        QuizNum_Reset(); //�����_�����X�g�̏�����
    }

    // Update is called once per frame
    void Update()
    {
        TextQuestionNum.GetComponent<Text>().text = csvDatas_QuestionNum[count][0];
        //TextQuestion.GetComponent<Text>().text = csvDatas_Question[count][0];
        TextQuestion.GetComponent<Text>().text = csvDatas_Question[quiz_num][0];
    }

    public void CountPlus()
    {
        count++;
    }

    public void CountReset()
    {
        count = 0;
    }

    public void CorrectCount_Puls()
    {
        correct_count++;
    }
    public void CorrectCount_Reset()
    {
        correct_count = 0;
    }

    public void QuizNum_Change()
    {
        quiz_num = random[count];
    }

    public void QuizNum_Reset()
    {
        //�N�C�Y�̐����X�g�ɐ���������
        for (int i = 0; i < QuizMax; i++)
        {
            random.Add(i);
        }
        //�K���ɏ��Ԃ����ւ���
        for (int i = 0; i < QuizMax; i++)
        {
            int work = random[i];
            int index = Random.Range(0, random.Count);
            random[i] = random[index];
            random[index] = work;

        }

        quiz_num = random[0];
    }
}
