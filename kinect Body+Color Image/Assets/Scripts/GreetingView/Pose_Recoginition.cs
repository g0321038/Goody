using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose_Recoginition : MonoBehaviour
{
    public GameObject GetInfo;
    public GameObject Text_All_Good;
    public GameObject Text_Head;
    public GameObject Text_HandRight;
    public GameObject Text_HandLeft;
    public GameObject Text_ElowRight;
    public GameObject Text_ElowLeft;

    //GetInformationで取得したジョイントのポジションを格納する配列
    private Vector3[] joint_position_array = new Vector3[25];
    private Vector3 joint_position = new Vector3(0f, 0f, 0f);

    //各ジョイントの位置と基準（Criteria）位置の相対距離を格納する配列
    //基準を(SpineMid = 1)
    private Vector3[] joint_distance_array = new Vector3[25];
    private int Criteria = 1;

    //各関節との相対距離の判別基準値 Vector3型 (気を付け)
    private Vector3 distance_Head = new Vector3(0.085f, 3.2f, 0f);
    private Vector3 distance_SholderRight = new Vector3(1.3f, 1.3f, 0f);
    private Vector3 distance_SholderLeft = new Vector3(-1.3f, 1.3f, 0f);
    private Vector3 distance_ElbowRight = new Vector3(1.55f, -0.6f, 0f);
    private Vector3 distance_ElbowLeft = new Vector3(-1.55f, -0.6f, 0f);
    private Vector3 distance_HandRight = new Vector3(1.5f, -2.6f, 0f);
    private Vector3 distance_HandLeft = new Vector3(-1.5f, -2.6f, 0f);

    //判別基準値のVector3型配列
    private Vector3[] pose_standard_array = new Vector3[25];


    //誤差
    //private Vector3 calculation = new Vector3(0.5f, 0.5f, 0);
    private float cal = 0.6f;

    //各関節の位置の正誤判定用フラグ
    private bool HeadFlag; //jointcount:3
    private bool SholderRightFlag; //jointcount:8
    private bool SholderLeftFlag; //jointcount:4
    private bool ElbowRightFlag; //jointcount:9
    private bool ElbowLeftFlag; //jointcount:5
    private bool HandRightFlag; //jointcount:11
    private bool HandLeftFlag; //jointcount:7

    // Start is called before the first frame update
    void Start()
    {
        pose_standard_array[3] = distance_Head;
        pose_standard_array[9] = distance_ElbowRight;
        pose_standard_array[5] = distance_ElbowLeft;
        pose_standard_array[11] = distance_HandRight;
        pose_standard_array[7] = distance_HandLeft;
    }

    // Update is called once per frame
    void Update()
    {
        //各関節の位置を配列に格納する
        for (int jointcount = 0; jointcount < 25; jointcount++)
        {
            joint_position = GetInfo.GetComponent<GetInformation>().GetPosition(jointcount);
            joint_position_array[jointcount] = joint_position;
        }
        //-----------------------------------------------------------------------------------------------------

        //各関節の位置と基準（SpineMid）位置の相対距離を計算し格納する
        for(int jointcount = 0; jointcount < 25; jointcount++)
        {
            joint_distance_array[jointcount] = joint_position_array[jointcount] - joint_position_array[Criteria];
        }
        //------------------------------------------------------------------------------------------------------

        //for (jointcount = 0; jointcount < 25; jointcount++)
        //{
        //    if( (joint_distance_array[jointcount].x >= pose_standard_array[jointcount] - cal) && (joint_distance_array[jointcount].x <= pose_standard_array[jointcount] + cal) )
        //    {
        //        if ( (joint_distance_array[jointcount].x >= pose_standard_array[jointcount] - cal) && (joint_distance_array[jointcount].x <= pose_standard_array[jointcount] + cal) )
        //        {

        //        }
        //    }
        //}

        //正誤判定　Head 3
        if( (joint_distance_array[3].x >= distance_Head.x - cal) && (joint_distance_array[3].x <= distance_Head.x + cal))
        {
            if( (joint_distance_array[3].y >= distance_Head.y - cal) && (joint_distance_array[3].y <= distance_Head.y + cal))
            {
                HeadFlag = true;
                Text_Head.SetActive(true);
            }
        }
        else
        {
            HeadFlag = false;
            Text_Head.SetActive(false);
        }

        ////正誤判定　SholderRight 8
        //if ((joint_distance_array[8].x >= distance_SholderRight.x - cal) && (joint_distance_array[8].x <= distance_SholderRight.x + cal))
        //{
        //    if ((joint_distance_array[8].y >= distance_SholderRight.y - cal) && (joint_distance_array[8].y <= distance_SholderRight.y + cal))
        //    {
        //        SholderRightFlag = true;
        //    }
        //}
        //else
        //{
        //    SholderRightFlag = false;
        //}

        ////正誤判定　SholderLeft 4
        //if ((joint_distance_array[4].x >= distance_SholderLeft.x - cal) && (joint_distance_array[4].x <= distance_SholderLeft.x + cal))
        //{
        //    if ((joint_distance_array[4].y >= distance_SholderLeft.y - cal) && (joint_distance_array[4].y <= distance_SholderLeft.y + cal))
        //    {
        //        SholderLeftFlag = true;
        //    }
        //}
        //else
        //{
        //    SholderLeftFlag = false;
        //}

        //正誤判定　ElbowRight 9
        if ((joint_distance_array[9].x >= distance_ElbowRight.x - cal) && (joint_distance_array[9].x <= distance_ElbowRight.x + cal))
        {
            if ((joint_distance_array[9].y >= distance_ElbowRight.y - cal) && (joint_distance_array[9].y <= distance_ElbowRight.y + cal))
            {
                ElbowRightFlag = true;
                Text_ElowRight.SetActive(true);
            }
        }
        else
        {
            ElbowRightFlag = false;
            Text_ElowRight.SetActive(false);
        }

        //正誤判定　ElbowLeft 5
        if ((joint_distance_array[5].x >= distance_ElbowLeft.x - cal) && (joint_distance_array[5].x <= distance_ElbowLeft.x + cal))
        {
            if ((joint_distance_array[5].y >= distance_ElbowLeft.y - cal) && (joint_distance_array[5].y <= distance_ElbowLeft.y + cal))
            {
                ElbowLeftFlag = true;
                Text_ElowLeft.SetActive(true);
            }
        }
        else
        {
            ElbowLeftFlag = false;
            Text_ElowLeft.SetActive(false);
        }

        //正誤判定　HandRight 11
        if ((joint_distance_array[11].x >= distance_HandRight.x - cal) && (joint_distance_array[11].x <= distance_HandRight.x + cal))
        {
            if ((joint_distance_array[11].y >= distance_HandRight.y - cal) && (joint_distance_array[11].y <= distance_HandRight.y + cal))
            {
                HandRightFlag = true;
                Text_HandRight.SetActive(true);
                Debug.Log("HandRight is good");
            }
        }
        else
        {   
            HandRightFlag = false;
            Text_HandRight.SetActive(false);
        }

        //正誤判定　HandLeft 7
        if ((joint_distance_array[7].x >= distance_HandLeft.x - cal) && (joint_distance_array[7].x <= distance_HandLeft.x + cal))
        {
            if ((joint_distance_array[7].y >= distance_HandLeft.y - cal) && (joint_distance_array[7].y <= distance_HandLeft.y + cal))
            {
                HandLeftFlag = true;
                Text_HandLeft.SetActive(true);
            }
        }
        else
        {
            HandLeftFlag = false;
            Text_HandLeft.SetActive(false);
        }

        //各関節の位置の正誤判定が全部正しいかどうかtextを表示非表示
        if (HeadFlag == true && HandRightFlag == true && HandLeftFlag == true && ElbowRightFlag == true && ElbowLeftFlag == true)
        {
            Text_All_Good.SetActive(true);           
        }
        else
        {
            Text_All_Good.SetActive(false);
        }
    }
}
