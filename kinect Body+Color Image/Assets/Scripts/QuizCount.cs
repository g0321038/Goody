using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class QuizCount : MonoBehaviour
{
    public int count; //クイズの出題した数のカウント

    public int quiz_num; //クイズの番号

    public int correct_count; //クイズ正解数カウント

    public int QuizMax;

    public GameObject TextQuestionNum;

    public GameObject TextQuestion;

    public GameObject TextJudgeManager;

    private TextAsset csvFile_QuestionNum; //csvfile

    private TextAsset csvFile_Question; //csvfile

    private List<string[]> csvDatas_QuestionNum = new List<string[]>(); //csvの中身を入れるリスト
    
    private List<string[]> csvDatas_Question = new List<string[]>(); //csvの中身を入れるリスト

    private List<int> random = new List<int>(); //ランダム用リスト

    private int QuestionMax; //クイズの数

    // Start is called before the first frame update
    void Start()
    {
        //csvFileとして読み込む
        csvFile_Question = Resources.Load("Texts/Quiz/Quiz1/QuestionText") as TextAsset;
        csvFile_QuestionNum = Resources.Load("Texts/Quiz/Quiz1/QuestionNumText") as TextAsset;
        
        StringReader reader_Question = new StringReader(csvFile_Question.text);
        StringReader reader_QuestionNum = new StringReader(csvFile_QuestionNum.text);

        while (reader_Question.Peek() != -1)
        {
            string line = reader_Question.ReadLine(); //一行ずつ読み込み
            csvDatas_Question.Add(line.Split(',')); //,区切りでリストに追加
        }

        while (reader_QuestionNum.Peek() != -1)
        {
            string line = reader_QuestionNum.ReadLine(); //一行ずつ読み込み
            csvDatas_QuestionNum.Add(line.Split(',')); //,区切りでリストに追加
        }

        QuizNum_Reset(); //ランダムリストの初期化
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
        //クイズの数リストに整数を入れる
        for (int i = 0; i < QuizMax; i++)
        {
            random.Add(i);
        }
        //適当に順番を入れ替える
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
