using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GreettoKinect : MonoBehaviour
{
    //canvas�ƒ���RawImage�̃��X�g���A�^�b�`
    public GameObject movie_canvas;
    public GameObject kinect_canvas;
    //public GameObject to_title_canvas;

    public List<GameObject> country_movie;

    //���惊�X�g�p�̃J�E���g
    public int count = 0;

    //VideoPlayer�R���|�[�l���g���g�p���邽��
    private VideoPlayer video;


    // Start is called before the first frame update
    void Start()
    {
        country_movie[count].GetComponent<VideoPlayer>().loopPointReached += FinishPlayVideo;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        //video.loopPointReached += FinishPlayVideo;

    }

    void FinishPlayVideo(VideoPlayer vp)
    {
        if (count <= 2)
        {
            country_movie[count].SetActive(false);
            movie_canvas.SetActive(false);
            kinect_canvas.SetActive(true);
            country_movie[count + 1].SetActive(true);
            country_movie[count + 1].GetComponent<VideoPlayer>().loopPointReached += FinishPlayVideo;
            count++;
        }
        else if (count == 3)
        {
            country_movie[count].SetActive(false);
            movie_canvas.SetActive(false);
            kinect_canvas.SetActive(true);
            count++;
        }
    }
  
}
