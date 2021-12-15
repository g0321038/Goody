using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject TextManager;
    public RectTransform ParentCanvas;
    public RectTransform Choices1Image;
    public RectTransform Choices2Image;

    quizTextManager quizTManager;

    private Vector3 LocalMousePos;

    private float HoldCount=0;

    bool SelectAnsFlag = false;

    string SelectAns;

    void Start()
    {

        quizTManager = TextManager.GetComponent<quizTextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectAnsFlag == false)//�������I�΂�Ă��Ȃ��ꍇ
        {
            CheckCursoronUI();
        }
        else
        {
            CheckTheAnswer();
        }
    }

    /*UI��ɃJ�[�\���������Ƃ��̏���*/
    void CheckCursoronUI()
    {
        /*�}�E�X�J�[�\�����L�����o�X�̃��[�J�����W�Ƃ��Ď擾*/
        LocalMousePos = ParentCanvas.InverseTransformPoint(Input.mousePosition);

       // Debug.Log(LocalMousePos);

        /*UI������������W�̐ݒ�i�ЂƂ߁j*/
        float Choice1_LTx = (ParentCanvas.InverseTransformPoint(Choices1Image.position)).x-(Choices1Image.sizeDelta.x)/2;//����x
        float Choice1_LTy = (ParentCanvas.InverseTransformPoint(Choices1Image.position)).y+(Choices1Image.sizeDelta.y)/2;//����y
        float Choice1_RBx = (ParentCanvas.InverseTransformPoint(Choices1Image.position)).x+(Choices1Image.sizeDelta.x)/2;//�E��x
        float Choice1_RBy = (ParentCanvas.InverseTransformPoint(Choices1Image.position)).y-(Choices1Image.sizeDelta.y)/2;//�E��y

        /*�ӂ���*/
        float Choice2_LTx = (ParentCanvas.InverseTransformPoint(Choices2Image.position)).x-(Choices2Image.sizeDelta.x)/2;//����x
        float Choice2_LTy = (ParentCanvas.InverseTransformPoint(Choices2Image.position)).y+(Choices2Image.sizeDelta.y)/2;//����y
        float Choice2_RBx = (ParentCanvas.InverseTransformPoint(Choices2Image.position)).x+(Choices2Image.sizeDelta.x)/2;//�E��x
        float Choice2_RBy = (ParentCanvas.InverseTransformPoint(Choices2Image.position)).y-(Choices2Image.sizeDelta.y)/2;//�E��y
       
        /*UI��ɃJ�[�\�������݂���ꍇ*/
        if (LocalMousePos.x > Choice1_LTx && LocalMousePos.x < Choice1_RBx && LocalMousePos.y > Choice1_RBy && LocalMousePos.y < Choice1_LTy)
        {
            HoldCount += Time.deltaTime;
            if (HoldCount > 3.0f)
            {
                SelectAnsFlag = true;
                SelectAns = "A";
                Debug.Log("Text1");
            }
        }
        else if(LocalMousePos.x > Choice2_LTx && LocalMousePos.x < Choice2_RBx && LocalMousePos.y > Choice2_RBy && LocalMousePos.y < Choice2_LTy)
        {
            HoldCount += Time.deltaTime;
            if (HoldCount > 3.0f)
            {
                SelectAnsFlag = true;
                SelectAns = "B";
                Debug.Log("Text2");
            }
        }
        else
            HoldCount = 0;
    }

    void CheckTheAnswer()
    {
        if (quizTManager.CsvDatas[quizTManager.QuizNum][3] == SelectAns)
        {
            Debug.Log("Atari");
        }
        else Debug.Log("Hazure");

        /*---------�����ɃN�C�Y�̃e�L�X�g�Ƃ��̏�����������������------*/
        SelectAnsFlag = false;
    }

}
