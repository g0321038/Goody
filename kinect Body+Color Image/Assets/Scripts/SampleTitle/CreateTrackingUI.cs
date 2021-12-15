using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Windows.Kinect;

//public class CreateTrackingUI : MonoBehaviour
//{
//    private GameObject obj;
//    private GameObject Master;
//    private bool Flag = true;
//    // 初期化
//    void Start()
//    {
//        // ResourcesフォルダからCubeプレハブのオブジェクトを取得
//        obj = (GameObject)Resources.Load("RightHand");
//        Master = GameObject.Find("Master");
//        //Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
//    }

//    void Update()
//    {
//        //ボディトラッキングされているかいないか

//        bool Tracked = Master.GetComponent<GetInformation>().GetTracked();

//        if (Tracked == true)
//        {
//            if (Flag == true)
//            {
//                Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
//                Flag = false;
//            }
//        }
//    }
//}

public class CreateTrackingUI : MonoBehaviour
{
    public BodySourceManager _BodySourceManager;

    private GameObject obj;
    private bool Tracked;
    private bool UIFlag = false;

    // 初期化
    void Start()
    {
        // ResourcesフォルダからCubeプレハブのオブジェクトを取得
        obj = (GameObject)Resources.Load("RightHand");
    }

    void Update()
    {
        //BodySourceManaferが取得できているか
        if (_BodySourceManager == null)
        {
            Debug.Log("_BodySourceManager is null");
            return;
        }

        //Bodyデータを取得する
        var data = _BodySourceManager.GetData();
        if (data == null)
        {
            Debug.Log("data is null");
            return;
        }

        //最初に追跡している人を取得する
        var body = data.FirstOrDefault(b => b.IsTracked);

        //var body = _BodySourceManager.GetData().FirstOrDefault(b => b.IsTracked);

        if (body == null)
        {
            Debug.Log("body is not tracked");
            Tracked = false;
        }
        else
        {
            Debug.Log("body is tracked");
            Tracked = true;
        }

        if (Tracked == true)
        {
            if (UIFlag == false)
            {
                Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                UIFlag = true;
            }
        }
    }
}

