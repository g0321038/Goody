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

    private JudgeText script;//�v���C���[���񓚒��������łȂ����𔻒f���邽�߂ɕϐ����擾������

    private GameObject TextJudgeManager;

    private float TimeCount = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        ParentCanvas = GameObject.Find("AnswerAction_Canvas");//Canvas��e�I�u�W�F�N�g�ɂ��邽�ߌ���
        CanvasTr = ParentCanvas.GetComponent<RectTransform>();
        ThisObj = gameObject.GetComponent<RectTransform>();

        /*�����ʒu�̐ݒ�*/
        Localpos = ThisObj.localPosition;
        Localpos.x = CanvasTr.sizeDelta.x / 2;

        //y���W�̓����_���Őݒ�
        Localpos.y = Random.Range(-(CanvasTr.sizeDelta.y / 2), CanvasTr.sizeDelta.y / 2);

        ThisObj.localPosition = Localpos;

        //���x�������_���Őݒ�
        velocity = Random.Range(0.5f, 1.5f);
        /*�A���t�@�x�b�g�̐ݒ�*/
        GameObject child = transform.Find("Text").gameObject;

        Text Alphabet_text = child.GetComponent<Text>();

        Alphabet_text.text = Alphabet;

        //TextJudgeManager�Q�[���I�u�W�F�N�g�̎擾
        TextJudgeManager = GameObject.Find("TextJudgeManager");

        //JudgeText�X�N���v�g�̎擾
        script = TextJudgeManager.GetComponent<JudgeText>();

        KinectInfo = GameObject.Find("KinectInfo");
    }

    // Update is called once per frame
    void Update()
    {

        /*�������g���ړ������鏈��*/
        if (Localpos.x >= -CanvasTr.sizeDelta.x / 2)
        {
            Localpos.x -= (velocity * (Time.deltaTime * 1000.0f));
            //Debug.Log(Time.deltaTime);
            ThisObj.localPosition = Localpos;
        }
        else/*�G��ꂽ��*/
        {

            Destroy(this.gameObject);
        }

        /*�A���t�@�x�b�g��UI�����Ƀ}�E�X���擾����*/
        if (script.AnsweredFlag == 1)//�񓚒�
        {
            TimeCount += Time.deltaTime;//�񓚗������b�N���邽�߂Ƀf�B���C
            if (TimeCount > 1.0f)//1�b�ȏ�Ȃ�
            {
                TimeCount = 0;
                //script.AnsweredFlag = 0;//�񓚌��̕���
                GameObject AnswerText = GameObject.Find("Answer");
                Text Answer = AnswerText.GetComponent<Text>();
                Answer.text = "";//�񓚗����󗓂�
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
        ///*�}�E�X�J�[�\�����L�����o�X�̃��[�J�����W�Ƃ��Ď擾*/
        //LocalMousePos = CanvasTr.InverseTransformPoint(Input.mousePosition);

        //float Cloud_LTx = (CanvasTr.InverseTransformPoint(this.transform.position)).x - (ThisObj.sizeDelta.x) / 2;//����x
        //float Cloud_LTy = (CanvasTr.InverseTransformPoint(this.transform.position)).y + (ThisObj.sizeDelta.y) / 2;//����y
        //float Cloud_RBx = (CanvasTr.InverseTransformPoint(this.transform.position)).x + (ThisObj.sizeDelta.x) / 2;//�E��x
        //float Cloud_RBy = (CanvasTr.InverseTransformPoint(this.transform.position)).y - (ThisObj.sizeDelta.y) / 2;//�E��y

        ///*UI��ɃJ�[�\�������݂���ꍇ*/
        //if (LocalMousePos.x > Cloud_LTx && LocalMousePos.x < Cloud_RBx && LocalMousePos.y > Cloud_RBy && LocalMousePos.y < Cloud_LTy)
        //{

        //    GameObject AnswerText = GameObject.Find("Answer");
        //    Text Answer = AnswerText.GetComponent<Text>();
        //    Answer.text += Alphabet;

        //    Destroy(gameObject);
        //    /*-------���̃I�u�W�F�N�g���폜&�A���t�@�x�b�g�̃f�[�^�𑗂�---------*/

        //    //HoldCount += Time.deltaTime;
        //    //if (HoldCount > 3.0f)
        //    //{
        //    //    SelectAnsFlag = true;
        //    //    SelectAns = "A";
        //    //    Debug.Log("Text1");
        //    //}
        //}

        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));
       
        float Cloud_LTx = (CanvasTr.InverseTransformPoint(this.transform.position)).x - (ThisObj.sizeDelta.x) / 2;//����x
        float Cloud_LTy = (CanvasTr.InverseTransformPoint(this.transform.position)).y + (ThisObj.sizeDelta.y) / 2;//����y
        float Cloud_RBx = (CanvasTr.InverseTransformPoint(this.transform.position)).x + (ThisObj.sizeDelta.x) / 2;//�E��x
        float Cloud_RBy = (CanvasTr.InverseTransformPoint(this.transform.position)).y - (ThisObj.sizeDelta.y) / 2;//�E��y
        /*UI��ɃJ�[�\�������݂���ꍇ*/
        if (JointPosition.x > Cloud_LTx && JointPosition.x < Cloud_RBx && JointPosition.y > Cloud_RBy && JointPosition.y < Cloud_LTy)
        {
            GameObject AnswerText = GameObject.Find("Answer");
            Text Answer = AnswerText.GetComponent<Text>();
            Answer.text += Alphabet;

            Destroy(this.gameObject);
        }
    }

}
