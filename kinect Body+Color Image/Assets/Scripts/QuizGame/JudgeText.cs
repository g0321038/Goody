using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Answer�ɏ����ꂽ���e���琳���̔��������
��̃I�u�W�F�N�g�ɃA�^�b�`
 */
public class JudgeText : MonoBehaviour
{

    public GameObject AnswerObj;

    public GameObject Action_canvas;
    
    public GameObject Question_canvas;

    public GameObject Result_canvas;

    public GameObject MarkImage;

    public GameObject CorrectCount_Text;

    public int QuestionMax;

    public AudioClip[] sound; //SE�����@0:���� 1:�s����

    private AudioSource audioSource; //�����R���|�[�l���g

    private GameObject QuizCountManager;

    private int QuestionNum; //�N�C�Y�̔ԍ�

    private int QuestionCount; //�N�C�Y�̏o�萔�̃J�E���g

    private Text AnswerText;

    private int WordCount;

    public int AnswerCount = 0;

    public int AnsweredFlag;

    public int SceneMoveFlag;

    private float SceneMoveDelay;

    //�񓚂̐��딻��p��CSV
    private TextAsset csvFile_Correct_Answer; //csvfile

    private List<string[]> csvDatas_Correct_Answer = new List<string[]>(); //csv�̒��g�����郊�X�g

    // Start is called before the first frame update
    void Start()
    {
        AnswerText = AnswerObj.GetComponent<Text>();
        /*�����̃f�[�^�����炩���߃��[�h*/

        AnswerText.text = "";

        //CountryNum = 0;

        SceneMoveDelay = 0;

        QuizCountManager = GameObject.Find("QuizCountManager");

        QuestionMax--;

        csvFile_Correct_Answer = Resources.Load("Texts/Quiz/Quiz1/Correct_Answer") as TextAsset;
        StringReader reader_Correct_Answer = new StringReader(csvFile_Correct_Answer.text);
        while (reader_Correct_Answer.Peek() != -1)
        {
            string line = reader_Correct_Answer.ReadLine(); //��s���ǂݍ���
            csvDatas_Correct_Answer.Add(line.Split(',')); //,��؂�Ń��X�g�ɒǉ�
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //QuestionNum = QuizCountManager.GetComponent<QuizCount>().count;
        QuestionNum = QuizCountManager.GetComponent<QuizCount>().quiz_num;

        QuestionCount = QuizCountManager.GetComponent<QuizCount>().count;

        WordCount = AnswerText.text.Length;

        
        //Debug.Log(WordCount);
        Debug.Log("QuestionNum = " + QuestionNum);
        Debug.Log("AnswerFlag = " + AnsweredFlag);
        //Debug.Log("SceneMoveDelay" + SceneMoveDelay);

        if (AnsweredFlag == 0)
        {
            if (WordCount >= 3)
            {
                if (AnswerText.text == csvDatas_Correct_Answer[QuestionNum][0])
                {
                    AnswerText.text = "Collect!!!";
                    
                    //�����̉摜��ǂݍ���ŃI�u�W�F�N�g���A�N�e�B�u��
                    MarkImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/maru");
                    MarkImage.SetActive(true);

                    //SE��炷
                    audioSource.PlayOneShot(sound[0]);

                    //�V�[���ړ��t���O���P
                    SceneMoveFlag = 1;

                    //�N�C�Y���𐔃J�E���g���v���X
                    QuizCountManager.GetComponent<QuizCount>().CorrectCount_Puls();

                    Debug.Log("Collect!!!");
                }
                else
                {
                    AnswerText.text = "Failed...";

                    //�s�����̉摜��ǂݍ���ŃI�u�W�F�N�g���A�N�e�B�u��
                    MarkImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/batu");
                    MarkImage.SetActive(true);

                    //SE��炷
                    audioSource.PlayOneShot(sound[1]);

                    Debug.Log("Failed");
                }
                AnsweredFlag = 1;
            }
        }
        

        if (AnsweredFlag == 1)//����t���O��Ŏ��̃V�[���ɑJ��
        {
            //�V�[���ړ��t���O���P��
            SceneMoveFlag = 1;
        }

        if (SceneMoveFlag == 1)
        {
            SceneMoveDelay += Time.deltaTime;

            if (SceneMoveDelay > 2.0f)
            {
                //if (QuestionNum < QuestionMax) //����̔ԍ�������̍ő�l�𒴂��������U���g�ց@����ȊO�͎��̎����
                if (QuestionCount < QuestionMax)
                {
                    //�V�[���ړ�(Questiontext)
                    NextQuestion();
                }
                else
                {
                    //�V�[�����ړ�(result)
                    Quiz2Movie();
                }
            }
        }


    }
    void Quiz2Movie()
    {
        //������̏�����
        AnswerText.text = "";

        //�f�B���C�J�E���g�̃��Z�b�g
        SceneMoveDelay = 0;

        //���[�h�J�E���g�̃��Z�b�g
        WordCount = 0;

        //�񓚉񐔂̃��Z�b�g
        AnsweredFlag = 0;

        //�v���n�u����̃I�u�W�F�N�g�����ׂď�������
        GameObject selection = GameObject.Find("SelectionObject");
        Destroy(selection);

        //�V�[���J�ڃt���O��0�ɕς��A����s�����摜�̃I�u�W�F�N�g���A�N�e�B�u��
        SceneMoveFlag = 0;
        MarkImage.SetActive(false);

        //�N�C�Y�J�E���g�����Z�b�g
        QuizCountManager.GetComponent<QuizCount>().CountReset();

        //�N�C�Y���𐔂��e�L�X�g�I�u�W�F�N�g�֓n��
        int correct_count = QuizCountManager.GetComponent<QuizCount>().correct_count;
        CorrectCount_Text.GetComponent<Text>().text = correct_count.ToString();

        //�N�C�Y���𐔃J�E���g�����Z�b�g
        QuizCountManager.GetComponent<QuizCount>().CorrectCount_Reset();

        //�����_�����X�g�����Z�b�g���ăN�C�Y�ԍ��ɂ͔z��̐擪��
        QuizCountManager.GetComponent<QuizCount>().QuizNum_Reset();

        //�V�[���J��
        Result_canvas.SetActive(true);
        Action_canvas.SetActive(false);
    }

    void NextQuestion()
    {
        //������̏�����
        AnswerText.text = "";

        //�f�B���C�J�E���g�̃��Z�b�g
        SceneMoveDelay = 0;

        //���[�h�J�E���g�̃��Z�b�g
        WordCount = 0;

        //�񓚉񐔂̃��Z�b�g
        AnsweredFlag = 0;

        //�v���n�u����̃I�u�W�F�N�g�����ׂď�������
        GameObject selection = GameObject.Find("SelectionObject");
        Destroy(selection);

        //�V�[���J�ڃt���O��0�ɕς��A����s�����摜�̃I�u�W�F�N�g���A�N�e�B�u��
        SceneMoveFlag = 0;
        MarkImage.SetActive(false);

        //�N�C�Y�J�E���g�𑝂₷
        QuizCountManager.GetComponent<QuizCount>().CountPlus();

        //�N�C�Y�̔ԍ���ς���
        QuizCountManager.GetComponent<QuizCount>().QuizNum_Change();

        //�V�[���J��
        Question_canvas.SetActive(true);
        Action_canvas.SetActive(false);

        
    }
}
