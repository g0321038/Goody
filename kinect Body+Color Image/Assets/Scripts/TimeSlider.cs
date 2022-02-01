using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeSlider : MonoBehaviour
{
    public GameObject slider;//表示するスライダーのオブジェクト

    public GameObject[] Button;//ボタンオブジェクト

    public int DestinationFlag;//遷移先判別用フラグ

    public int ButtonNum; //ボタンの数

    public int CanvasNum; //ボタン数のうち、canvasのアクティブ設定を変更するボタンの数

    private int OnButtonNum; //どのボタンが押されているか

    private float time;//時間

    private int JointCount = 11;//右手のジョイント番号
    
    private Vector3 JointPosition = new Vector3(0, 0, 0);//ジョイントの位置
   
    private GameObject KinectInfo;//kinectからの情報取得用

    private bool ActiveFlag = false; //ボタンの上に操作UIが存在するかどうかのフラグ

    private Vector3[] LeftBottom;
    private Vector3[] RightTop;
    private Vector2[] ButtonSize;

    public AudioClip sound; //SE音源

    private AudioSource audioSource; //音源コンポーネント
    private int SoundFlag; //SEが鳴ったかどうか 

    // Start is called before the first frame update
    void Start()
    {
        KinectInfo = GameObject.Find("KinectInfo");

        LeftBottom = new Vector3[ButtonNum];
        RightTop = new Vector3[ButtonNum];
        ButtonSize = new Vector2[ButtonNum];

        //ボタンの範囲を配列に格納
        for (int i = 0; i < ButtonNum; i++)
        {
            ButtonSize[i] = Vector2.Scale(Button[i].GetComponent<RectTransform>().sizeDelta, new Vector2(0.5f, 0.5f));
            LeftBottom[i] = Button[i].GetComponent<RectTransform>().anchoredPosition - ButtonSize[i];
            RightTop[i] = Button[i].GetComponent<RectTransform>().anchoredPosition + ButtonSize[i];
        }

        //音源コンポーネントの取得
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
                    //キャンバス切り替え
                    Button[OnButtonNum].GetComponent<ChangeCanvas>().OnClick();
                    SoundFlag = 0;
                }
                else
                {
                    //シーン切り替え
                    Button[OnButtonNum].GetComponent<ChangeScene>().OnClick();
                    SoundFlag = 0;
                }
            }
            else if (DestinationFlag == 1)
            {
                if(OnButtonNum != 4)
                {
                    //キャンバス切り替え（Photoシーンへ）
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
                //クイズの問題からのキャンバス切り替え（分岐）
                Button[OnButtonNum].GetComponent<BranchCanvas>().OnClick();
                SoundFlag = 0;
            }
        }
    }



    //ボタン上に操作UIが存在している間スライダーを表示する（ボタンの番号も取得する）
    //スライダーは時間で増加し、ボタンから外れるとリセットされる
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

