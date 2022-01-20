using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class quizTextManager : MonoBehaviour
{
    public GameObject QuestionCanvas;
    public GameObject QuestionObj;
    public GameObject ChoiceObj1;
    public GameObject ChoiceObj2;
    

    public int LineCount=0;/*csv�t�@�C���̍s���J�E���g�p*/

    TextAsset CsvFile;/*csv�t�@�C���Ǘ��p*/

    public List<string[]> CsvDatas = new List<string[]>();/*�e�L�X�g�i�[�p�ɓ��I�ȓ񎟌��z��錾*/

    public int QuizNum;

    // �N�C�Y�f�[�^��csv���[�h
    void Start()
    {
        Debug.Log(ChoiceObj1.transform.position);
        Debug.Log(QuestionCanvas.transform.InverseTransformPoint(ChoiceObj1.transform.position));
        Debug.Log(ChoiceObj2.transform.position);
        Debug.Log(ChoiceObj2.transform.localPosition);

        CsvFile = Resources.Load("Texts/Quiz/QuizText") as TextAsset;/*�ǂݍ���csv�t�@�C����TextAsset�Ƃ��ĊǗ�����C���[�W�H*/
        StringReader reader = new StringReader(CsvFile.text);/*csv�t�@�C���̃e�L�X�g�f�[�^�擾*/
        
        while(reader.Peek()!=-1)/*�s�̖����܂œǂݍ���*/
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            CsvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
            LineCount += 1;
        }
        Debug.Log(LineCount);

    }


    bool PushFlag=false;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Return)&&PushFlag==false)/*�e�L�X�g�؂�ւ��̃g���K�[���Ƃ肠�����G���^�[�L�[�ɂ���*/
        {
            PushFlag = true;
            ChangeText();
        }
        else if(Input.GetKey(KeyCode.Return)==false)
        {
            PushFlag = false;
        }

        
    }

    void ChangeText()
    {
        QuizNum = Random.Range(0,LineCount);/*�N�C�Y�ԍ�����*/
        /*��蕶�\����*/
        Text QuestionText = QuestionObj.GetComponent<Text>();
        QuestionText.text = CsvDatas[QuizNum][0];

        /*�I�����\����1*/
        Text ChoiceText1 = ChoiceObj1.GetComponent<Text>();
        ChoiceText1.text = CsvDatas[QuizNum][1];

        /*�I�����\����2*/
        Text ChoiceText2 = ChoiceObj2.GetComponent<Text>();
        ChoiceText2.text = CsvDatas[QuizNum][2];
    }

}
