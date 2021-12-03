using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class GetJointPosition : MonoBehaviour
{
    public GameObject BodySourceManager;
    public Camera ConvertCamera;

    private BodySourceManager _BodyManager;

    private Kinect.CoordinateMapper _CoordinateMapper;
    private int _KinectWidth = 1920;
    private int _KinectHeight = 1080;

    private Vector3[] PositionArray = new Vector3[25];

    public Vector3 GetPosition(int jointcount)
    {
        return PositionArray[jointcount];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //BodySouceManager���g�����߂̏���
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
        /*---------------------------------------------------------------------*/

        //CoordinateMapper���g�����߂̏���  
        if (_CoordinateMapper == null)
        {
            _CoordinateMapper = _BodyManager.Sensor.CoordinateMapper;
        }

        foreach (var body in data)
        {
            if(body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
                {
                    Kinect.Joint TargetJoint = body.Joints[jt];
                    int jtcount = GetCountFormJointType(jt);
                    PositionArray[jtcount] = GetVector3FromJoint(TargetJoint);
                }
            }

           
        }
    }

    private Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        var valid = joint.TrackingState != Kinect.TrackingState.NotTracked;
        if (ConvertCamera != null || valid)
        {
            // Kinect��Camera���W�n(3����)��Color���W�n(2����)�ɕϊ�����
            var point = _CoordinateMapper.MapCameraPointToColorSpace(joint.Position);
            var point2 = new Vector3(point.X, point.Y, 0);
            if ((0 <= point2.x) && (point2.x < _KinectWidth) &&
                 (0 <= point2.y) && (point2.y < _KinectHeight))
            {

                // �X�N���[���T�C�Y�Œ���(Kinect->Unity)
                point2.x = point2.x * Screen.width / _KinectWidth;
                point2.y = point2.y * Screen.height / _KinectHeight;

                // Unity�̃��[���h���W�n(3����)�ɕϊ�
                var colorPoint3 = ConvertCamera.ScreenToWorldPoint(point2);

                // ���W�̒���
                // Y���W�͋t�AZ���W��-1�ɂ���(X���~���[��Ԃɂ���ċt�ɂ���K�v����)
                colorPoint3.y *= -1;
                colorPoint3.z = -1;

                return colorPoint3;
            }
        }

        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, -1);
    }

    //�W���C���g�^�C�v��int�^�ɕϊ�����֐��@�@�i�����W���C���g�^�C�v�@�߂�lint�^�j
    private�@int GetCountFormJointType(Kinect.JointType jt)
    {
        int count;
        switch (jt)
        {
            case Kinect.JointType.SpineBase:
                count = 0;
                break;

            case Kinect.JointType.SpineMid:
                count = 1;
                break;

            case Kinect.JointType.Neck:
                count = 2;
                break;

            case Kinect.JointType.Head:
                count = 3;
                break;

            case Kinect.JointType.ShoulderLeft:
                count = 4;
                break;

            case Kinect.JointType.ElbowLeft:
                count = 5;
                break;

            case Kinect.JointType.WristLeft:
                count = 6;
                break;

            case Kinect.JointType.HandLeft:
                count = 7;
                break;

            case Kinect.JointType.ShoulderRight:
                count = 8;
                break;

            case Kinect.JointType.ElbowRight:
                count = 9;
                break;

            case Kinect.JointType.WristRight:
                count = 10;
                break;

            case Kinect.JointType.HandRight:
                count = 11;
                break;

            case Kinect.JointType.HipLeft:
                count = 12;
                break;

            case Kinect.JointType.KneeLeft:
                count = 13;
                break;

            case Kinect.JointType.AnkleLeft:
                count = 14;
                break;

            case Kinect.JointType.FootLeft:
                count = 15;
                break;

            case Kinect.JointType.HipRight:
                count = 16;
                break;

            case Kinect.JointType.KneeRight:
                count = 17;
                break;

            case Kinect.JointType.AnkleRight:
                count = 18;
                break;

            case Kinect.JointType.FootRight:
                count = 19;
                break;

            case Kinect.JointType.SpineShoulder:
                count = 20;
                break;

            case Kinect.JointType.HandTipLeft:
                count = 21;
                break;

            case Kinect.JointType.ThumbLeft:
                count = 22;
                break;

            case Kinect.JointType.HandTipRight:
                count = 23;
                break;

            case Kinect.JointType.ThumbRight:
                count = 24;
                break;

            default:
                count = 0;
                break;
        }
        return count;
    }
}
