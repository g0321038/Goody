using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose_Recoginition : MonoBehaviour
{
    //GetInformationで取得したジョイントのポジションを格納する配列
    private Vector3[] joint_position_array = new Vector3[25];
    private Vector3 joint_position = new Vector3(0f, 0f, 0f);

    //各ジョイントの位置と基準（Criteria）位置の相対距離を格納する配列
    //基準を(SpineMid = 1)
    private Vector3[] joint_distance  = new Vector3[25];
    private int Criteria = 1;

    //各関節との相対距離の判別基準値 Vector3型
    private Vector3 distance_Head = new Vector3(0.08525f, 3.23030f, 0f);
    private Vector3 distance_SholderRight = new Vector3(1.30324f, 1.21184f, 0f);
    private Vector3 distance_SholderLeft = new Vector3(-1.26110f, 1.38935f, 0f);
    private Vector3 distance_ElbowRight = new Vector3(1.54481f, -0.57679f, 0f);
    private Vector3 distance_ElbowLeft = new Vector3(-1.62922f, -0.61865f, 0f);
    private Vector3 distance_HandRight = new Vector3(1.54451f, -2.61136f, 0f);
    private Vector3 distance_HandLeft = new Vector3(-1.41580f, -2.63937f, 0f);

    //Vector3型の要素はfloat型
    private float[] distance_Head_item = new float[] { 0.08525f, 3.23030f, 0f };
    private float[] distance_SholderRight_item = new float[] { 1.30324f, 1.21184f, 0f };

    //誤差
    private Vector3 calculation = new Vector3(0.15f, 0.15f, 0);
    private float cal = 0.15f;

    public GameObject GetInfo;

    // Start is called before the first frame update
    void Start()
    {
        
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

        //各関節の位置と基準（SpineMid）位置の相対距離を計算し格納する
        for(int jointcount = 0; jointcount < 25; jointcount++)
        {
            joint_distance[jointcount] = joint_position_array[jointcount] - joint_position_array[Criteria];
        }

        //Debug.Log(joint_distance[11]);

        //誤差0.3以下ならデバック表示
        if( (joint_distance[3].x >= distance_Head.x - cal) && (joint_distance[3].x <= distance_Head.x + cal))
        {
            if( (joint_distance[3].y >= distance_Head.y - cal) && (joint_distance[3].y <= distance_Head.y + cal))
            {
                Debug.Log("Head Position is Good!!!");
            }
        }
        else
        {
            Debug.Log("Bad Position!!!");
        }
        
      

    }
}
