using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeSlider : MonoBehaviour
{
    public GameObject slider;
    //public GameObject Button;
    public GameObject[] Button;

    public int ButtonNum; //ボタンの数

    public int CanvasNum; //ボタン数のうち、canvasのアクティブ設定を変更するボタンの数

    private int OnButtonNum; //どのボタンが押されているか

    private float time;

    private int JointCount = 11;
    private Vector3 JointPosition = new Vector3(0, 0, 0);
    private GameObject KinectInfo;

    private bool ActiveFlag = false;

    private Vector3[] LeftBottom;
    private Vector3[] RightTop;
    private Vector2[] ButtonSize;
    //private Vector3[] V2toV3;

    // Start is called before the first frame update
    void Start()
    {
        KinectInfo = GameObject.Find("KinectInfo");

        LeftBottom = new Vector3[ButtonNum];
        RightTop = new Vector3[ButtonNum];
        ButtonSize = new Vector2[ButtonNum];

        for (int i = 0; i < ButtonNum; i++)
        {
            ButtonSize[i] = Vector2.Scale(Button[i].GetComponent<RectTransform>().sizeDelta, new Vector2(0.5f, 0.5f));
            LeftBottom[i] = Button[i].GetComponent<RectTransform>().anchoredPosition - ButtonSize[i];
            RightTop[i] = Button[i].GetComponent<RectTransform>().anchoredPosition + ButtonSize[i];
        }


        //Debug.Log(LeftBottom);
        //Debug.Log(RightTop);
    }

    // Update is called once per frame
    void Update()
    {
        OnButton();

        //OnButton(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        if (time >= 3)
        {
            //if(NextSceneName.Length == 0)
            //   {
            //       time = 0;
            //       Button.GetComponent<ChangeCanvas>().OnClick();
            //   }   
            //else
            //   {
            //       time = 0;
            //       SceneManager.LoadScene(NextSceneName);
            //   }

            time = 0;

            if (OnButtonNum < CanvasNum)
            {
                Button[OnButtonNum].GetComponent<ChangeCanvas>().OnClick();
            }
            else
            {
                Button[OnButtonNum].GetComponent<ChangeScene>().OnClick();
            }

        }
    }

    void OnButton()
    {
        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));

        //if ((LeftBottom[0].x <= JointPosition.x && RightTop[0].x >= JointPosition.x) && (LeftBottom[0].y <= JointPosition.y && RightTop[0].y >= JointPosition.y))
        //{
        //    slider.SetActive(true);
        //    ActiveFlag = true;
        //    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
        //    time += Time.deltaTime;
        //    slider.GetComponent<Slider>().value = time;
        //    OnButtonNum = 0;
        //    Debug.Log(time);
        //}
        //else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
        //{
        //    slider.SetActive(true);
        //    ActiveFlag = true;
        //    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
        //    time += Time.deltaTime;
        //    slider.GetComponent<Slider>().value = time;
        //    OnButtonNum = 1;
        //    Debug.Log(time);
        //}
        //else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
        //{
        //    slider.SetActive(true);
        //    ActiveFlag = true;
        //    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
        //    time += Time.deltaTime;
        //    slider.GetComponent<Slider>().value = time;
        //    OnButtonNum = 2;
        //    Debug.Log(time);
        //}
        //else if ((LeftBottom[3].x <= JointPosition.x && RightTop[3].x >= JointPosition.x) && (LeftBottom[3].y <= JointPosition.y && RightTop[3].y >= JointPosition.y))
        //{
        //    slider.SetActive(true);
        //    ActiveFlag = true;
        //    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
        //    time += Time.deltaTime;
        //    slider.GetComponent<Slider>().value = time;
        //    OnButtonNum = 3;
        //    Debug.Log(time);
        //}
        //else
        //{
        //    time = 0;
        //    if (ActiveFlag == true)
        //    {
        //        slider.SetActive(false);
        //        ActiveFlag = false;
        //    }

        //}

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
                    Debug.Log(time);
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
                    Debug.Log(time);
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                    Debug.Log(time);
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
                    Debug.Log(time);
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                    Debug.Log(time);
                }
                else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 2;
                    Debug.Log(time);
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
                    Debug.Log(time);
                }
                else if ((LeftBottom[1].x <= JointPosition.x && RightTop[1].x >= JointPosition.x) && (LeftBottom[1].y <= JointPosition.y && RightTop[1].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 1;
                    Debug.Log(time);
                }
                else if ((LeftBottom[2].x <= JointPosition.x && RightTop[2].x >= JointPosition.x) && (LeftBottom[2].y <= JointPosition.y && RightTop[2].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 2;
                    Debug.Log(time);
                }
                else if ((LeftBottom[3].x <= JointPosition.x && RightTop[3].x >= JointPosition.x) && (LeftBottom[3].y <= JointPosition.y && RightTop[3].y >= JointPosition.y))
                {
                    slider.SetActive(true);
                    ActiveFlag = true;
                    slider.GetComponent<RectTransform>().anchoredPosition = JointPosition + new Vector3(0, 60, 0);
                    time += Time.deltaTime;
                    slider.GetComponent<Slider>().value = time;
                    OnButtonNum = 3;
                    Debug.Log(time);
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

