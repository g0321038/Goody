using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SerifManager : MonoBehaviour
{
    public GameObject CanvasText;

    public List<string> textsArray = new List<string>();/*�Z���t�i�[�p�̓��I�Ȕz��錾*/
    // Start is called before the first frame update
    void Start()
    {
        string datapath = Application.dataPath + "/Texts/test.txt";/*�e�L�X�g�t�@�C���̃p�X�w��*/
        Debug.Log(datapath);
        using (var fs = new StreamReader(datapath, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)/*�t�@�C���̖����܂ŒT��*/
            {
                textsArray.Add(fs.ReadLine());/*�e�L�X�g�t�@�C����1�s����textsArray�ɒǉ�*/
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            DrawText(0);
            Debug.Log(textsArray[0]);
        }

    }

    void DrawText(int number)
    {
        Text SerifText=CanvasText.GetComponent<Text>();

        SerifText.text = textsArray[number];

    }

}
