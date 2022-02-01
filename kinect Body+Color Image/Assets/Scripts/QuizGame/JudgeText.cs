using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Answerに書かれた内容から正解の判定をする
空のオブジェクトにアタッチ
 */
public class JudgeText : MonoBehaviour
{

    public GameObject AnswerObj;

    public GameObject Action_canvas;
    
    public GameObject Question_canvas;

    public GameObject Result_canvas;

    public GameObject MarkImage;

    public GameObject CorrectCount_Text;

    public int QuestionMax;

    public AudioClip[] sound; //SE音源　0:正解 1:不正解

    private AudioSource audioSource; //音源コンポーネント

    private GameObject QuizCountManager;

    private int QuestionNum; //クイズの番号

    private int QuestionCount; //クイズの出題数のカウント

    private Text AnswerText;

    private int WordCount;

    public int AnswerCount = 0;

    public int AnsweredFlag;

    public int SceneMoveFlag;

    private float SceneMoveDelay;

    //回答の正誤判定用のCSV
    private TextAsset csvFile_Correct_Answer; //csvfile

    private List<string[]> csvDatas_Correct_Answer = new List<string[]>(); //csvの中身を入れるリスト

    // Start is called before the first frame update
    void Start()
    {
        AnswerText = AnswerObj.GetComponent<Text>();
        /*答えのデータをあらかじめロード*/

        AnswerText.text = "";

        //CountryNum = 0;

        SceneMoveDelay = 0;

        QuizCountManager = GameObject.Find("QuizCountManager");

        QuestionMax--;

        csvFile_Correct_Answer = Resources.Load("Texts/Quiz/Quiz1/Correct_Answer") as TextAsset;
        StringReader reader_Correct_Answer = new StringReader(csvFile_Correct_Answer.text);
        while (reader_Correct_Answer.Peek() != -1)
        {
            string line = reader_Correct_Answer.ReadLine(); //一行ずつ読み込み
            csvDatas_Correct_Answer.Add(line.Split(',')); //,区切りでリストに追加
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //QuestionNum = QuizCountManager.GetComponent<QuizCount>().count;
        QuestionNum = QuizCountManager.GetComponent<QuizCount>().quiz_num;

        QuestionCount = QuizCountManager.GetComponent<QuizCount>().count;

        WordCount = AnswerText.text.Length;

        
        //Debug.Log(WordCount);
        Debug.Log("QuestionNum = " + QuestionNum);
        Debug.Log("AnswerFlag = " + AnsweredFlag);
        //Debug.Log("SceneMoveDelay" + SceneMoveDelay);

        if (AnsweredFlag == 0)
        {
            if (WordCount >= 3)
            {
                if (AnswerText.text == csvDatas_Correct_Answer[QuestionNum][0])
                {
                    AnswerText.text = "Collect!!!";
                    
                    //正解の画像を読み込んでオブジェクトをアクティブ化
                    MarkImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/maru");
                    MarkImage.SetActive(true);

                    //SEを鳴らす
                    audioSource.PlayOneShot(sound[0]);

                    //シーン移動フラグを１
                    SceneMoveFlag = 1;

                    //クイズ正解数カウントをプラス
                    QuizCountManager.GetComponent<QuizCount>().CorrectCount_Puls();

                    Debug.Log("Collect!!!");
                }
                else
                {
                    AnswerText.text = "Failed...";

                    //不正解の画像を読み込んでオブジェクトをアクティブ化
                    MarkImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/batu");
                    MarkImage.SetActive(true);

                    //SEを鳴らす
                    audioSource.PlayOneShot(sound[1]);

                    Debug.Log("Failed");
                }
                AnsweredFlag = 1;
            }
        }
        

        if (AnsweredFlag == 1)//お手付き三回で次のシーンに遷移
        {
            //シーン移動フラグを１に
            SceneMoveFlag = 1;
        }

        if (SceneMoveFlag == 1)
        {
            SceneMoveDelay += Time.deltaTime;

            if (SceneMoveDelay > 2.0f)
            {
                //if (QuestionNum < QuestionMax) //質問の番号が質問の最大値を超えた時リザルトへ　それ以外は次の質問へ
                if (QuestionCount < QuestionMax)
                {
                    //シーン移動(Questiontext)
                    NextQuestion();
                }
                else
                {
                    //シーンを移動(result)
                    Quiz2Movie();
                }
            }
        }


    }
    void Quiz2Movie()
    {
        //文字列の初期化
        AnswerText.text = "";

        //ディレイカウントのリセット
        SceneMoveDelay = 0;

        //ワードカウントのリセット
        WordCount = 0;

        //回答回数のリセット
        AnsweredFlag = 0;

        //プレハブからのオブジェクトをすべて消去する
        GameObject selection = GameObject.Find("SelectionObject");
        Destroy(selection);

        //シーン遷移フラグを0に変え、正解不正解画像のオブジェクトを非アクティブ化
        SceneMoveFlag = 0;
        MarkImage.SetActive(false);

        //クイズカウントをリセット
        QuizCountManager.GetComponent<QuizCount>().CountReset();

        //クイズ正解数をテキストオブジェクトへ渡す
        int correct_count = QuizCountManager.GetComponent<QuizCount>().correct_count;
        CorrectCount_Text.GetComponent<Text>().text = correct_count.ToString();

        //クイズ正解数カウントをリセット
        QuizCountManager.GetComponent<QuizCount>().CorrectCount_Reset();

        //ランダムリストをリセットしてクイズ番号には配列の先頭を
        QuizCountManager.GetComponent<QuizCount>().QuizNum_Reset();

        //シーン遷移
        Result_canvas.SetActive(true);
        Action_canvas.SetActive(false);
    }

    void NextQuestion()
    {
        //文字列の初期化
        AnswerText.text = "";

        //ディレイカウントのリセット
        SceneMoveDelay = 0;

        //ワードカウントのリセット
        WordCount = 0;

        //回答回数のリセット
        AnsweredFlag = 0;

        //プレハブからのオブジェクトをすべて消去する
        GameObject selection = GameObject.Find("SelectionObject");
        Destroy(selection);

        //シーン遷移フラグを0に変え、正解不正解画像のオブジェクトを非アクティブ化
        SceneMoveFlag = 0;
        MarkImage.SetActive(false);

        //クイズカウントを増やす
        QuizCountManager.GetComponent<QuizCount>().CountPlus();

        //クイズの番号を変える
        QuizCountManager.GetComponent<QuizCount>().QuizNum_Change();

        //シーン遷移
        Question_canvas.SetActive(true);
        Action_canvas.SetActive(false);

        
    }
}
