using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class quizTextManager : MonoBehaviour
{
    public GameObject QuestionCanvas;
    public GameObject QuestionObj;
    public GameObject ChoiceObj1;
    public GameObject ChoiceObj2;
    

    public int LineCount=0;/*csvファイルの行数カウント用*/

    TextAsset CsvFile;/*csvファイル管理用*/

    public List<string[]> CsvDatas = new List<string[]>();/*テキスト格納用に動的な二次元配列宣言*/

    public int QuizNum;

    // クイズデータのcsvロード
    void Start()
    {
        Debug.Log(ChoiceObj1.transform.position);
        Debug.Log(QuestionCanvas.transform.InverseTransformPoint(ChoiceObj1.transform.position));
        Debug.Log(ChoiceObj2.transform.position);
        Debug.Log(ChoiceObj2.transform.localPosition);

        CsvFile = Resources.Load("Texts/Quiz/QuizText") as TextAsset;/*読み込んだcsvファイルをTextAssetとして管理するイメージ？*/
        StringReader reader = new StringReader(CsvFile.text);/*csvファイルのテキストデータ取得*/
        
        while(reader.Peek()!=-1)/*行の末尾まで読み込み*/
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            CsvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            LineCount += 1;
        }
        Debug.Log(LineCount);

    }


    bool PushFlag=false;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Return)&&PushFlag==false)/*テキスト切り替えのトリガーをとりあえずエンターキーにする*/
        {
            PushFlag = true;
            ChangeText();
        }
        else if(Input.GetKey(KeyCode.Return)==false)
        {
            PushFlag = false;
        }

        
    }

    void ChangeText()
    {
        QuizNum = Random.Range(0,LineCount);/*クイズ番号決定*/
        /*問題文表示部*/
        Text QuestionText = QuestionObj.GetComponent<Text>();
        QuestionText.text = CsvDatas[QuizNum][0];

        /*選択肢表示部1*/
        Text ChoiceText1 = ChoiceObj1.GetComponent<Text>();
        ChoiceText1.text = CsvDatas[QuizNum][1];

        /*選択肢表示部2*/
        Text ChoiceText2 = ChoiceObj2.GetComponent<Text>();
        ChoiceText2.text = CsvDatas[QuizNum][2];
    }

}
