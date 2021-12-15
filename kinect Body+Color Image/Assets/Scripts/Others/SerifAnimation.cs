using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SerifAnimation : MonoBehaviour
{
    public Transform FukidashiImage;

    private float movePerFlame=1.0f;

    Vector3 FukidashiImagePos;

    float AnimationFlame;

    // Start is called before the first frame update
    void Start()
    {
        FukidashiImagePos = FukidashiImage.localPosition;
        //Invoke("TextAnimation", 3);
        //  StartCoroutine("AnimationCoroutine");
        AnimationFlame = 3 / Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (FukidashiImage.localPosition.x>280)
        {
            FukidashiImage.localPosition -= new Vector3(movePerFlame, 0, 0);
        }
        else
        {

            FukidashiImage.localPosition = FukidashiImagePos;
        }
        
    }

    void TextAnimation()
    {
        FukidashiImage.localPosition = FukidashiImagePos;/*座標のリセット*/

        /*総フレーム数（3秒の場合）*/
        float AnimationFlame = 3 / Time.deltaTime;
        Debug.Log(Time.deltaTime);
        int Count = 0;

        while (Count < (int)AnimationFlame)
        {
            Debug.Log(FukidashiImage.localPosition.x);
            FukidashiImage.localPosition -= new Vector3(movePerFlame, 0, 0);
            Count++;

        }

    }

}
