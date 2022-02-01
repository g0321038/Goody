using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float TextTime; //一行が表示されている時間
    public int TextRow; //CSVの行数
    public string FilePath; //CSVのファイルの場所
    public GameObject TextObj;

    private TextAsset csvFile; //csvfile
    private List<string[]> csvDatas = new List<string[]>(); //csvの中身を入れるリスト

    

    private int TextCount = 0; //テキストファイルの行カウント

    private float time = 0; //時間カウント 

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load(FilePath) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine(); //一行ずつ読み込み
            csvDatas.Add(line.Split(',')); //,区切りでリストに追加
        }
        Text text = TextObj.GetComponent<Text>();
        text.text = csvDatas[TextCount][0];

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if (time >= TextTime)
        {
            TextCount += 1;
            time = 0;
            if(TextCount < TextRow)
            {
                Text text = TextObj.GetComponent<Text>();
                text.text = csvDatas[TextCount][0];
            }
        }
    }
}
