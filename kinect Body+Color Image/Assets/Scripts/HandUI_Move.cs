using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI_Move : MonoBehaviour
{
    private int JointCount = 11; //右手のジョイントカウント
    private Vector3 JointPosition; //kinectからの右手の座標を格納
    private GameObject Script;　//GetPositionが書かれているスクリプト(GetInformation)のアタッチされているGameObject

    // Start is called before the first frame update
    void Start()
    {
        Script = GameObject.Find("KinectInfo");
    }

    // Update is called once per frame
    void Update()
    {
        //右手の座標を読み込む（Kinectの座標系を100倍することでcanvasのサイズに合わせられる）
        JointPosition = Vector3.Scale(Script.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));
        GetComponent<RectTransform>().anchoredPosition = JointPosition;
        //Debug.Log(JointPosition);
    }
}
