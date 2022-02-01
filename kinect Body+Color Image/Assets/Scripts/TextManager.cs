using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float TextTime; //��s���\������Ă��鎞��
    public int TextRow; //CSV�̍s��
    public string FilePath; //CSV�̃t�@�C���̏ꏊ
    public GameObject TextObj;

    private TextAsset csvFile; //csvfile
    private List<string[]> csvDatas = new List<string[]>(); //csv�̒��g�����郊�X�g

    

    private int TextCount = 0; //�e�L�X�g�t�@�C���̍s�J�E���g

    private float time = 0; //���ԃJ�E���g 

    // Start is called before the first frame update
    void Start()
    {
        csvFile = Resources.Load(FilePath) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine(); //��s���ǂݍ���
            csvDatas.Add(line.Split(',')); //,��؂�Ń��X�g�ɒǉ�
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
