using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SerifControl : MonoBehaviour
{
    public GameObject SerifObj;/*テキストを変更するゲームオブジェクト*/

    public string serifPath;/*Resources以下のcsvファイルのパス*/

    int LineCount = 0;/*csvファイルの行数カウント用*/

    TextAsset CsvFile;/*Csvファイル管理用*/
    List<string[]> CsvDatas = new List<string[]>();/*テキスト格納用に動的な二次元配列宣言*/


    // Start is called before the first frame update
    void Start()
    {
        CsvFile = Resources.Load(serifPath) as TextAsset;/*読み込んだcsvファイルをTextAssetとして管理するイメージ？*/
        StringReader reader = new StringReader(CsvFile.text);/*csvファイルのテキストデータ取得*/

        while (reader.Peek() != -1)/*行の末尾まで読み込み*/
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            CsvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            LineCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text SerifText = SerifObj.GetComponent<Text>();
        SerifText.text = CsvDatas[0][0];

    }
}
