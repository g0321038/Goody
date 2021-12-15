using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SerifManager : MonoBehaviour
{
    public GameObject CanvasText;

    public List<string> textsArray = new List<string>();/*セリフ格納用の動的な配列宣言*/
    // Start is called before the first frame update
    void Start()
    {
        string datapath = Application.dataPath + "/Texts/test.txt";/*テキストファイルのパス指定*/
        Debug.Log(datapath);
        using (var fs = new StreamReader(datapath, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)/*ファイルの末尾まで探索*/
            {
                textsArray.Add(fs.ReadLine());/*テキストファイルの1行ずつをtextsArrayに追加*/
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
