using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeSlider : MonoBehaviour
{
    public GameObject slider;//�\������X���C�_�[�̃I�u�W�F�N�g

    public GameObject[] Button;//�{�^���I�u�W�F�N�g

    public int DestinationFlag;//�J�ڐ攻�ʗp�t���O

    public int ButtonNum; //�{�^���̐�

    public int CanvasNum; //�{�^�����̂����Acanvas�̃A�N�e�B�u�ݒ��ύX����{�^���̐�

    private int OnButtonNum; //�ǂ̃{�^����������Ă��邩

    private float time;//����

    private int JointCount = 11;//�E��̃W���C���g�ԍ�
    
    private Vector3 JointPosition = new Vector3(0, 0, 0);//�W���C���g�̈ʒu
   
    private GameObject KinectInfo;//kinect����̏��擾�p

    private bool ActiveFlag = false; //�{�^���̏�ɑ���UI�����݂��邩�ǂ����̃t���O

    private Vector3[] LeftBottom;
    private Vector3[] RightTop;
    private Vector2[] ButtonSize;

    public AudioClip sound; //SE����

    private AudioSource audioSource; //�����R���|�[�l���g
    private int SoundFlag; //SE���������ǂ��� 

    // Start is called before the first frame update
    void Start()
    {
        KinectInfo = GameObject.Find("KinectInfo");

        LeftBottom = new Vector3[ButtonNum];
        RightTop = new Vector3[ButtonNum];
        ButtonSize = new Vector2[ButtonNum];

        //�{�^���͈̔͂�z��Ɋi�[
        for (int i = 0; i < ButtonNum; i++)
        {
            ButtonSize[i] = Vector2.Scale(Button[i].GetComponent<RectTransform>().sizeDelta, new Vector2(0.5f, 0.5f));
            LeftBottom[i] = Button[i].GetComponent<RectTransform>().anchoredPosition - ButtonSize[i];
            RightTop[i] = Button[i].GetComponent<RectTransform>().anchoredPosition + ButtonSize[i];
        }

        //�����R���|�[�l���g�̎擾
        audioSource = GetComponent<AudioSource>();

        //Debug.Log(LeftBottom);
        //Debug.Log(RightTop);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(time);
        OnButton();
        if(time >= 2.8)
        {
            if (SoundFlag == 0)
            {
                audioSource.PlayOneShot(sound);
                SoundFlag = 1;
            }
        }
        
        if (time >= 3)
        {
            time = 0;
            
            if (DestinationFlag == 0)
            {
                if (OnButtonNum < CanvasNum)
                {
                    //�L�����o�X�؂�ւ�
                    Button[OnButtonNum].GetComponent<ChangeCanvas>().OnClick();
                    SoundFlag = 0;
                }
                else
                {
                    //�V�[���؂�ւ�
                    Button[OnButtonNum].GetComponent<ChangeScene>().OnClick();
                    SoundFlag = 0;
                }
            }
            else if (DestinationFlag == 1)
            {
                if(OnButtonNum != 4)
                {
                    //�L�����o�X�؂�ւ��iPhoto�V�[���ցj
                    Button[OnButtonNum].GetComponent<SelectPhoto>().OnClick();
                    SoundFlag = 0;
                }
                else
                {
                    Button[OnButtonNum].GetComponent<ChangeScene>().OnClick();
                    SoundFlag = 0;
                }
                
            }
            else if (DestinationFlag == 2)
            {
                //�N�C�Y�̖�肩��̃L�����o�X�؂�ւ��i����j
                Button[OnButtonNum].GetComponent<BranchCanvas>().OnClick();
                SoundFlag = 0;
            }
        }
    }



    //�{�^����ɑ���UI�����݂��Ă���ԃX���C�_�[��\������i�{�^���̔ԍ����擾����j
    //�X���C�_�[�͎��Ԃő������A�{�^������O���ƃ��Z�b�g�����
    void OnButton()
    {
        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));
        //Debug.Log("Position = " + JointPosition);
        
        switch (ButtonNum)
        {
            case 1:
                if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 0;
                    //Debug.Log(time);
                }
                else
                {
                    time = 0;
                    if (ActiveFlag == true)
                    {
                        slider.SetActive(false);
                        ActiveFlag = false;
                    }

                }
                break;

            case 2:
                if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 0;
                   // Debug.Log(time);
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                   // Debug.Log(time);
                }
                else
                {
                    time = 0;
                    if (ActiveFlag == true)
                    {
                        slider.SetActive(false);
                        ActiveFlag = false;
                    }

                }
                break;

            case 3:
                if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 0;
                   // Debug.Log(time);
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                   //Debug.Log(time);
                }
                else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 2;
                   // Debug.Log(time);
                }
                else
                {
                    time = 0;
                    if (ActiveFlag == true)
                    {
                        slider.SetActive(false);
                        ActiveFlag = false;
                    }

                }
                break;

            case 4:
                if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 0;
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                }
                else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 2;
                }
                else if ((LeftBottom[3].x <= JointPosition.x && RightTop[3].x >= JointPosition.x) && (LeftBottom[3].y <= JointPosition.y && RightTop[3].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 3;
                }
                else
                {
                    time = 0;
                    if (ActiveFlag == true)
                    {
                        slider.SetActive(false);
                        ActiveFlag = false;
                    }

                }
                break;
            case 5:
                if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 0;
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                }
                else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 2;
                }
                else if ((LeftBottom[3].x <= JointPosition.x && RightTop[3].x >= JointPosition.x) && (LeftBottom[3].y <= JointPosition.y && RightTop[3].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 3;
                }
                else if ((LeftBottom[4].x <= JointPosition.x && RightTop[4].x >= JointPosition.x) && (LeftBottom[4].y <= JointPosition.y && RightTop[4].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 4;
                }
                else
                {
                    time = 0;
                    if (ActiveFlag == true)
                    {
                        slider.SetActive(false);
                        ActiveFlag = false;
                    }

                }
                break;

            default:
                break;
        }
    }
}

