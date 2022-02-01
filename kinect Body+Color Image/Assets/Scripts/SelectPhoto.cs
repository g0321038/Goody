using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SelectPhoto : MonoBehaviour
{
    public GameObject Sphere;

    public GameObject Canvas;

    public Material[] material;

    public int ButtonNum;

    public Text TextObj1;

    public Text TextObj2;

    private string DataPath;

    public void OnClick()
    {
        Renderer r = Sphere.GetComponent<Renderer>();
        r.material = material[ButtonNum];

        GameObject MenuCanvas = GameObject.Find("MenuCanvas");

        ExplainText_Set();
        
        Canvas.SetActive(true);
        MenuCanvas.SetActive(false);

    }

    void ExplainText_Set()
    {
        switch (ButtonNum)
        {
            case 0:
                DataPath = "Texts/Quiz/Quiz1/Hawai_Explain";
                break;
            case 1:
                DataPath = "Texts/Quiz/Quiz1/Japan_Explain";
                break;
            case 2:
                DataPath = "Texts/Quiz/Quiz1/Thailand_Explain";
                break;
            case 3:
                DataPath = "Texts/Quiz/Quiz1/Zimbabwe_Explain";
                break;
            default:
                break;
        }

        List<string[]> csvDatas = new List<string[]>();�@//csv�̒��g�����郊�X�g
        TextAsset Explain_Text = Resources.Load(DataPath) as TextAsset; 
        StringReader Reader = new StringReader(Explain_Text.text);

        int Line_Count = 0; //�s���J�E���g

        if(Reader != null)
        {
            while (Reader.Peek() != -1)
            {
                string line = Reader.ReadLine(); //��s���ǂݍ���
                csvDatas.Add(line.Split(',')); //,��؂�Ń��X�g�ɒǉ�
                Line_Count += 1;
            }

            TextObj1.text = csvDatas[0][0];

            TextObj2.text = csvDatas[1][0];
            TextObj2.text += "\n";

            for (int i = 2; i < Line_Count; i++)
            {
                TextObj2.text += csvDatas[i][0];
                TextObj2.text += "\n";
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
