using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kinect = Windows.Kinect;



public class TouchRightHand : MonoBehaviour
{
    public GameObject BodySourceManager;
    //public GameObject ColorBodySourceView;

    private BodySourceManager _BodyManager;
    //private ColorBodySourceView _ColorBodyView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //BodySourceManagerからのデータの取得　初期化？
        if (BodySourceManager == null)
        {
            return;
        }

        _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null)
        {
            return;
        }

        Kinect.Body[] data = _BodyManager.GetData();
        if (data == null)
        {
            return;
        }
        /*------------------------------------------------------*/

        ////ColorBodySourceViewからデータの取得　初期化？
        //if (ColorBodySourceView == null)
        //{
        //    return;
        //}

        //_ColorBodyView = ColorBodySourceView.GetComponent<ColorBodySourceView>();
        //if (_ColorBodyView == null)
        //{
        //    return;
        //}
        //Dictionary<ulong, GameObject> _Bodies = _ColorBodyView.GetBodies();
        //if (_Bodies == null)
        //{
        //    return;
        //}
        /*-----------------------------------------------------*/
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            { 
                GameObject BodyObj = GameObject.Find("Bodies"); 

                if (TargetInErea(body, BodyObj))
                {
                    SceneManager.LoadScene("Result");
                }
            }
        }
        

    }

    private bool TargetInErea(Kinect.Body body, GameObject bodies)
    {
        string str1 = "Body:";
        ulong num = body.TrackingId;
        string str2 = num.ToString();
        string str3 = str1 + str2;
        Transform bodyObject = bodies.transform.Find(str3);
        Kinect.Joint TargetJoint = body.Joints[Kinect.JointType.HandRight];
        Transform JointObj = bodyObject.transform.Find("HandRight");

        var HandRightPosition = new Vector3(0, 0, 0);
        HandRightPosition = JointObj.localPosition;

        Debug.Log("Position = " + HandRightPosition);

        if((HandRightPosition.x >= 4 && HandRightPosition.x <= 6) && (HandRightPosition.y >= 3 && HandRightPosition.y <= 4))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
