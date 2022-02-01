using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CollectUIAlphabet : MonoBehaviour
{

    private GameObject ParentCanvas;
    private RectTransform CanvasTr;
    private RectTransform ThisObj;

    //private Vector3 LocalMousePos;
    private Vector3 JointPosition;
    private int JointCount = 11;
    private GameObject KinectInfo;

    public Vector3 Localpos;

    public float velocity = 3.0f;

    public string Alphabet;

    private JudgeText script;//プレイヤーが回答中かそうでないかを判断するために変数を取得したい

    private GameObject TextJudgeManager;

    private float TimeCount = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        ParentCanvas = GameObject.Find("AnswerAction_Canvas");//Canvasを親オブジェクトにするため検索
        CanvasTr = ParentCanvas.GetComponent<RectTransform>();
        ThisObj = gameObject.GetComponent<RectTransform>();

        /*初期位置の設定*/
        Localpos = ThisObj.localPosition;
        Localpos.x = CanvasTr.sizeDelta.x / 2;

        //y座標はランダムで設定
        Localpos.y = Random.Range(-(CanvasTr.sizeDelta.y / 2), CanvasTr.sizeDelta.y / 2);

        ThisObj.localPosition = Localpos;

        //速度もランダムで設定
        velocity = Random.Range(0.5f, 1.5f);
        /*アルファベットの設定*/
        GameObject child = transform.Find("Text").gameObject;

        Text Alphabet_text = child.GetComponent<Text>();

        Alphabet_text.text = Alphabet;

        //TextJudgeManagerゲームオブジェクトの取得
        TextJudgeManager = GameObject.Find("TextJudgeManager");

        //JudgeTextスクリプトの取得
        script = TextJudgeManager.GetComponent<JudgeText>();

        KinectInfo = GameObject.Find("KinectInfo");
    }

    // Update is called once per frame
    void Update()
    {

        /*自分自身を移動させる処理*/
        if (Localpos.x >= -CanvasTr.sizeDelta.x / 2)
        {
            Localpos.x -= (velocity * (Time.deltaTime * 1000.0f));
            //Debug.Log(Time.deltaTime);
            ThisObj.localPosition = Localpos;
        }
        else/*触られた時*/
        {

            Destroy(this.gameObject);
        }

        /*アルファベットのUI内部にマウス→取得判定*/
        if (script.AnsweredFlag == 1)//回答中
        {
            TimeCount += Time.deltaTime;//回答欄をロックするためにディレイ
            if (TimeCount > 1.0f)//1秒以上なら
            {
                TimeCount = 0;
                //script.AnsweredFlag = 0;//回答権の復活
                GameObject AnswerText = GameObject.Find("Answer");
                Text Answer = AnswerText.GetComponent<Text>();
                Answer.text = "";//回答欄を空欄に
            }
        }
        else
        {
            GetAlphabet();
        }

        if(script.SceneMoveFlag == 1)
        {
            Destroy(this.gameObject);
        }

    }
    void GetAlphabet()
    {
        ///*マウスカーソルをキャンバスのローカル座標として取得*/
        //LocalMousePos = CanvasTr.InverseTransformPoint(Input.mousePosition);

        //float Cloud_LTx = (CanvasTr.InverseTransformPoint(this.transform.position)).x - (ThisObj.sizeDelta.x) / 2;//左上x
        //float Cloud_LTy = (CanvasTr.InverseTransformPoint(this.transform.position)).y + (ThisObj.sizeDelta.y) / 2;//左上y
        //float Cloud_RBx = (CanvasTr.InverseTransformPoint(this.transform.position)).x + (ThisObj.sizeDelta.x) / 2;//右下x
        //float Cloud_RBy = (CanvasTr.InverseTransformPoint(this.transform.position)).y - (ThisObj.sizeDelta.y) / 2;//右下y

        ///*UI上にカーソルが存在する場合*/
        //if (LocalMousePos.x > Cloud_LTx && LocalMousePos.x < Cloud_RBx && LocalMousePos.y > Cloud_RBy && LocalMousePos.y < Cloud_LTy)
        //{

        //    GameObject AnswerText = GameObject.Find("Answer");
        //    Text Answer = AnswerText.GetComponent<Text>();
        //    Answer.text += Alphabet;

        //    Destroy(gameObject);
        //    /*-------このオブジェクトを削除&アルファベットのデータを送る---------*/

        //    //HoldCount += Time.deltaTime;
        //    //if (HoldCount > 3.0f)
        //    //{
        //    //    SelectAnsFlag = true;
        //    //    SelectAns = "A";
        //    //    Debug.Log("Text1");
        //    //}
        //}

        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));
       
        float Cloud_LTx = (CanvasTr.InverseTransformPoint(this.transform.position)).x - (ThisObj.sizeDelta.x) / 2;//左上x
        float Cloud_LTy = (CanvasTr.InverseTransformPoint(this.transform.position)).y + (ThisObj.sizeDelta.y) / 2;//左上y
        float Cloud_RBx = (CanvasTr.InverseTransformPoint(this.transform.position)).x + (ThisObj.sizeDelta.x) / 2;//右下x
        float Cloud_RBy = (CanvasTr.InverseTransformPoint(this.transform.position)).y - (ThisObj.sizeDelta.y) / 2;//右下y
        /*UI上にカーソルが存在する場合*/
        if (JointPosition.x > Cloud_LTx && JointPosition.x < Cloud_RBx && JointPosition.y > Cloud_RBy && JointPosition.y < Cloud_LTy)
        {
            GameObject AnswerText = GameObject.Find("Answer");
            Text Answer = AnswerText.GetComponent<Text>();
            Answer.text += Alphabet;

            Destroy(this.gameObject);
        }
    }

}
