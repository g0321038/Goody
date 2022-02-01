using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

/*キャンバスを親オブジェクトに設定してインスタンスを生成するやつ*/
public class CreateAlphabets : MonoBehaviour
{
    TextAsset CsvFile;/*csvファイル管理用*/

    public List<string[]> AlphabetTabeles = new List<string[]>();/*テキスト格納用に動的な二次元配列宣言*/

    public GameObject ParentCanvas;

    public GameObject TextJudgeManager;
    private GameObject obj;

    CollectUIAlphabet script;

    public float TimeCount = 0.0f;

    public float cycle = 1.5f;

    public int LineCount = 0;/*csvファイルの行数カウント用*/

    // Start is called before the first frame update
    void Start()
    {
        obj = (GameObject)Resources.Load("Prefabs/Alphabet");
        /*アルファベットテーブルのロード*/
        //CsvFile = Resources.Load("Texts/Quiz/Quiz1/Alphabets") as TextAsset;/*読み込んだcsvファイルをTextAssetとして管理するイメージ？*/
        CsvFile = Resources.Load("Texts/Quiz/Quiz1/Answer_List") as TextAsset;/*読み込んだcsvファイルをTextAssetとして管理するイメージ？*/
        StringReader reader = new StringReader(CsvFile.text);/*csvファイルのテキストデータ取得*/

        while (reader.Peek() != -1)/*行の末尾まで読み込み*/
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            AlphabetTabeles.Add(line.Split(',')); // , 区切りでリストに追加
            LineCount += 1;
            Debug.Log(line);
        }

   

        
    }

    void Update()
    {
        if (TextJudgeManager.GetComponent<JudgeText>().SceneMoveFlag != 1)
        {
            if (TimeCount > cycle)//cycle秒周期で出現
            {
                TimeCount = 0.0f;//カウントをリセットする

                // プレハブを元にオブジェクトを生成する
                GameObject instance = (GameObject)Instantiate(obj, this.transform.position, Quaternion.identity);

                //親オブジェクトをキャンバスに設定
                instance.transform.parent = ParentCanvas.transform;

                //アルファベットの設定
                script = instance.GetComponent<CollectUIAlphabet>();

                //アルファベットテーブルから文字を持ってくる
                int AlphabetNum = Random.Range(0, LineCount);
                script.Alphabet = AlphabetTabeles[AlphabetNum][0];
                //Debug.Log(LineCount);

            }
            TimeCount += Time.deltaTime;
        }
    }


}
