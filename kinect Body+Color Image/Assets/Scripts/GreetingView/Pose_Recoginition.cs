using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pose_Recoginition : MonoBehaviour
{
    public GameObject GetInfo;
    public GameObject Text_All_Good;
    public GameObject Text_Head;
    public GameObject Text_HandRight;
    public GameObject Text_HandLeft;
    public GameObject Text_ElowRight;
    public GameObject Text_ElowLeft;
    public GameObject Button;
    public GameObject ModeSelect;
    public GameObject TimeText;
    public GameObject ImageObj;

    public AudioClip sound; //SE音源

    private AudioSource audioSource; //音源コンポーネント

    private int PoseNumber = 0;

    //時間用変数
    private float time = 0;
    //ポーズができたときの時間
    private float goodtime;
    //タイムリミット
    private float LimitTime = 60;
    private int OutTime;

    //GetInformationで取得したジョイントのポジションを格納する配列
    private Vector3[] joint_position_array = new Vector3[25];
    private Vector3 joint_position = new Vector3(0f, 0f, 0f);

    //各ジョイントの位置と基準（Criteria）位置の相対距離を格納する配列
    //基準を(SpineMid = 1)
    private Vector3[] joint_distance_array = new Vector3[25];
    private int Criteria = 1;

    //各関節との相対距離の判別基準値 Vector3型
    private Vector3[] distinction_array = new Vector3[25];

    //誤差
    //private Vector3 calculation = new Vector3(0.5f, 0.5f, 0);
    private float cal = 0.5f;

    //各関節の位置の正誤判定用フラグ
    private bool GoodFlag = false;
    private bool HeadFlag; //jointcount:3
    private bool SholderRightFlag; //jointcount:8
    private bool SholderLeftFlag; //jointcount:4
    private bool ElbowRightFlag; //jointcount:9
    private bool ElbowLeftFlag; //jointcount:5
    private bool HandRightFlag; //jointcount:11
    private bool HandLeftFlag; //jointcount:7

    private int SoundFlag = 0;
    // Start is called before the first frame update
    void Start()
    {
        goodtime = 100;
        ChangeImage();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        OutTime = (int)LimitTime - (int)time;
        time += Time.deltaTime;

        //各関節の位置を配列に格納する
        for (int jointcount = 0; jointcount < 25; jointcount++)
        {
            joint_position = GetInfo.GetComponent<GetInformation>().GetPosition(jointcount);
            joint_position_array[jointcount] = joint_position;
        }

        //各関節の位置と基準（SpineMid）位置の相対距離を計算し格納する
        for(int jointcount = 0; jointcount < 25; jointcount++)
        {
            joint_distance_array[jointcount] = joint_position_array[jointcount] - joint_position_array[Criteria];
        }


        //Poseごとに関節の相対距離の基準値を決定する
        Pose();
        
        //Poseの正誤判定とその処理
        Pose_is_Good();

        //Poseが正解した後の処理と時間切れ処理
        timepast();

        OutputTime();

        //Debug.Log("PoseNumber = " + PoseNumber);
        //Debug.Log("time = " + time);

    }

    void Pose()
    {
        Debug.Log("Pose || PoseNumber:" + PoseNumber);
        switch (PoseNumber)
        {
            case 0: //お辞儀 日本
                distinction_array[3] = new Vector3(0f, 3f, 0f);
                distinction_array[9] = new Vector3(1.75f, -0.1f, 0f);
                distinction_array[5] = new Vector3(-1.75f, -0.1f, 0f);
                distinction_array[11] = new Vector3(0.2f, -1.0f, 0f);
                distinction_array[7] = new Vector3(-0.2f, -1.0f, 0f);
                break;

            case 1: //手を合わせる　タイ
                distinction_array[3] = new Vector3(0f, 3f, 0f);
                distinction_array[9] = new Vector3(1.45f, -0.1f, 0f);
                distinction_array[5] = new Vector3(-1.45f, -0.1f, 0f);
                distinction_array[11] = new Vector3(0.1f, 0.65f, 0f);
                distinction_array[7] = new Vector3(-0.1f, 0.65f, 0f);
                break;

            case 2: //気を付け　サンプル
                distinction_array[3] = new Vector3(0f, 3f, 0f);
                distinction_array[9] = new Vector3(1.5f, 0.13f, 0f);
                distinction_array[5] = new Vector3(-0.5f, -0.02f, 0f);
                distinction_array[11] = new Vector3(1f, 1.4f, 0f);
                distinction_array[7] = new Vector3(1f, 1.4f, 0f);
                break;

            case 3: //手を振る？　ハワイ
                distinction_array[3] = new Vector3(0f, 3f, 0f);
                distinction_array[9] = new Vector3(1.6f, 0.04f, 0f);
                distinction_array[5] = new Vector3(-2.5f, 0.65f, 0f);
                distinction_array[11] = new Vector3(1.3f, -2.5f, 0f);
                distinction_array[7] = new Vector3(-2.25f, 2.5f, 0f);
                break;

            //case 4:
            //    distinction_array[3] = new Vector3(0f, 3f, 0f);
            //    distinction_array[9] = new Vector3(1.55f, -0.6f, 0f);
            //    distinction_array[5] = new Vector3(-1.55f, -0.6f, 0f);
            //    distinction_array[11] = new Vector3(1.5f, -2.6f, 0f);
            //    distinction_array[7] = new Vector3(-1.5f, -2.6f, 0f);
            //    break;

            default:
                break;
        }
    }

    void Pose_is_Good()
    {
        //Head JointCount3　正誤判定
        if ((joint_distance_array[3].x >= distinction_array[3].x - cal) && (joint_distance_array[3].x <= distinction_array[3].x + cal))
        {
            if ((joint_distance_array[3].y >= distinction_array[3].y - cal) && (joint_distance_array[3].y <= distinction_array[3].y + cal))
            {
                HeadFlag = true;
                //Text_Head.SetActive(true);
            }
        }
        else
        {
            HeadFlag = false;
            //Text_Head.SetActive(false);
        }
        
        //ElbowRight JointCount9 正誤判定
        if ((joint_distance_array[9].x >= distinction_array[9].x - cal) && (joint_distance_array[9].x <= distinction_array[9].x + cal))
        {
            if ((joint_distance_array[9].y >= distinction_array[9].y - cal) && (joint_distance_array[9].y <= distinction_array[9].y + cal))
            {
                ElbowRightFlag = true;
                //Text_ElowRight.SetActive(true);
            }
        }
        else
        {
            ElbowRightFlag = false;
            //Text_ElowRight.SetActive(false);
        }

        //ElbowLeft JointCount5 正誤判定
        if ((joint_distance_array[5].x >= distinction_array[5].x - cal) && (joint_distance_array[5].x <= distinction_array[5].x + cal))
        {
            if ((joint_distance_array[5].y >= distinction_array[5].y - cal) && (joint_distance_array[5].y <= distinction_array[5].y + cal))
            {
                ElbowLeftFlag = true;
               // Text_ElowLeft.SetActive(true);
            }
        }
        else
        {
            ElbowLeftFlag = false;
            //Text_ElowLeft.SetActive(false);
        }

        //HandRight JointCount11正誤判定
        if ((joint_distance_array[11].x >= distinction_array[11].x - cal) && (joint_distance_array[11].x <= distinction_array[11].x + cal))
        {
            if ((joint_distance_array[11].y >= distinction_array[11].y - cal) && (joint_distance_array[11].y <= distinction_array[11].y + cal))
            {
                HandRightFlag = true;
                //Text_HandRight.SetActive(true);
            }
        }
        else
        {
            HandRightFlag = false;
            //Text_HandRight.SetActive(false);
        }

        //HandLeft JointCount7 正誤判定
        if ((joint_distance_array[7].x >= distinction_array[7].x - cal) && (joint_distance_array[7].x <= distinction_array[7].x + cal))
        {
            if ((joint_distance_array[7].y >= distinction_array[7].y - cal) && (joint_distance_array[7].y <= distinction_array[7].y + cal))
            {
                HandLeftFlag = true;
                //Text_HandLeft.SetActive(true);
            }
        }
        else
        {
            HandLeftFlag = false;
            //Text_HandLeft.SetActive(false);
        }

        //各関節の位置の正誤判定が全部正しいかどうかtextを表示非表示
        if (HeadFlag == true && HandRightFlag == true && HandLeftFlag == true && ElbowRightFlag == true && ElbowLeftFlag == true)
        {
            Text_All_Good.SetActive(true);

            //GoodSEを鳴らす
            if(SoundFlag == 0)
            {
                audioSource.PlayOneShot(sound);
                SoundFlag = 1;
            }
            

            //最初のGoog判定の時間を格納　二回目以降リセットを防ぐ
            if (GoodFlag == false)
            {
                goodtime = time;
                GoodFlag = true;
            }
        }
    }

    void timepast()
    {
        if((time - goodtime) >= 3 || time >= LimitTime)
        {
            goodtime = 100;
            time = 0;
            GoodFlag = false;

            if(PoseNumber <= 2)
            {
                Text_All_Good.SetActive(false);
                Button.GetComponent<ChangeCanvas>().OnClick();
            }
            else
            {   
                Text_All_Good.SetActive(false);
                ModeSelect.GetComponent<ChangeScene>().OnClick();
            }
            SoundFlag = 0;
            PoseNumber++;
            ChangeImage();
        }
    }

    //制限時間を表示する
    void OutputTime()
    {
        Text outtext = TimeText.GetComponent<Text>();
        outtext.text = OutTime.ToString();
    }

    //画像の変更
    void ChangeImage()
    {
        Debug.Log("change Image || PoseNumber:" + PoseNumber);
        switch (PoseNumber)
        {
            case 0:
                ImageObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sample1");
                break;
            case 1:
                ImageObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sample2");
                break;
            case 2:
                ImageObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sample3");
                break;
            case 3:
                ImageObj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sample4");
                break;
            default:
                break;
        }
        
    }
}
