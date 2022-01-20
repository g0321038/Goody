using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI_Move : MonoBehaviour
{
    private int JointCount = 11; //�E��̃W���C���g�J�E���g
    private Vector3 JointPosition; //kinect����̉E��̍��W���i�[
    private GameObject Script;�@//GetPosition��������Ă���X�N���v�g(GetInformation)�̃A�^�b�`����Ă���GameObject

    // Start is called before the first frame update
    void Start()
    {
        Script = GameObject.Find("KinectInfo");
    }

    // Update is called once per frame
    void Update()
    {
        //�E��̍��W��ǂݍ��ށiKinect�̍��W�n��100�{���邱�Ƃ�canvas�̃T�C�Y�ɍ��킹����j
        JointPosition = Vector3.Scale(Script.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));
        GetComponent<RectTransform>().anchoredPosition = JointPosition;
        //Debug.Log(JointPosition);
    }
}
