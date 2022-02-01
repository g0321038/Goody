using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottunAction360 : MonoBehaviour
{
    public GameObject KinectInfo;

    public GameObject Camera;

    public GameObject[] Button; //0:Right 1:Left 2:Top 3:Bottom

    private Vector3 JointPosition = new Vector3(0, 0, 0);//ジョイントの位置

    private Transform Camaera_Transform;

    private Vector3 Rotate = new Vector3(0, 0, 0);

    //ボタン情報格納
    private Vector3[] LeftBottom;
    private Vector3[] RightTop;
    private Vector2[] ButtonSize;

    //ボタン判定のフラグ
    private int ButtonFlag; //押されているかいないか
    private int OnButtonNum; //ボタンの番号

    // Start is called before the first frame update
    void Start()
    {
        //Kinect情報取得
        KinectInfo = GameObject.Find("KinectInfo");

        //カメラトランスフォームの取得
        Camaera_Transform = Camera.transform;

        LeftBottom = new Vector3[Button.Length];
        RightTop = new Vector3[Button.Length];
        ButtonSize = new Vector2[Button.Length];

        //ボタンの範囲を配列に格納
        for (int i = 0; i < Button.Length; i++)
        {
            ButtonSize[i] = Vector2.Scale(Button[i].GetComponent<RectTransform>().sizeDelta, new Vector2(0.5f, 0.5f));
            LeftBottom[i] = Button[i].GetComponent<RectTransform>().anchoredPosition - ButtonSize[i];
            RightTop[i] = Button[i].GetComponent<RectTransform>().anchoredPosition + ButtonSize[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnButton();

        if(ButtonFlag == 1)
        {
            MoveCamara(OnButtonNum);
            Debug.Log(OnButtonNum);
        }
    }

    void OnButton()
    {
        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(11), new Vector3(250, 150, 1));

        if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
        {
            ButtonFlag = 1;
            OnButtonNum = 0;
        }
        else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
        {
            ButtonFlag = 1;
            OnButtonNum = 1;
        }
        else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
        {
            ButtonFlag = 1;
            OnButtonNum = 2;
        }
        else if ((LeftBottom[3].x <= JointPosition.x && RightTop[3].x >= JointPosition.x) && (LeftBottom[3].y <= JointPosition.y && RightTop[3].y >= JointPosition.y))
        {
            ButtonFlag = 1;
            OnButtonNum = 3;
        }
        else
        {
            OnButtonNum = -1;

            if (ButtonFlag == 1)
            {
                ButtonFlag = 0;
            }
        }
    }

    void MoveCamara(int Num)
    {       
        switch (Num)
        {
            case 0:
                Rotate += new Vector3(0.0f, 0.5f, 0.0f);
                break;
            case 1:
                Rotate += new Vector3(0.0f, -0.5f, 0.0f);
                break;
            case 2:
                Rotate += new Vector3(-0.5f, 0.0f, 0.0f);
                break;
            case 3:
                Rotate += new Vector3(0.5f, 0.0f, 0.0f);
                break;
            default:
                break;
        }
        Rotate.x %= (float)360;
        Rotate.y %= (float)360;

        Camaera_Transform.eulerAngles = Rotate;
    }
}
