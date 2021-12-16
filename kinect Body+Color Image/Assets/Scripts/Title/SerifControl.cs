using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SerifControl : MonoBehaviour
{
    public GameObject SerifObj;/*�e�L�X�g��ύX����Q�[���I�u�W�F�N�g*/

    public string serifPath;/*Resources�ȉ���csv�t�@�C���̃p�X*/

    int LineCount = 0;/*csv�t�@�C���̍s���J�E���g�p*/

    TextAsset CsvFile;/*Csv�t�@�C���Ǘ��p*/
    List<string[]> CsvDatas = new List<string[]>();/*�e�L�X�g�i�[�p�ɓ��I�ȓ񎟌��z��錾*/


    // Start is called before the first frame update
    void Start()
    {
        CsvFile = Resources.Load(serifPath) as TextAsset;/*�ǂݍ���csv�t�@�C����TextAsset�Ƃ��ĊǗ�����C���[�W�H*/
        StringReader reader = new StringReader(CsvFile.text);/*csv�t�@�C���̃e�L�X�g�f�[�^�擾*/

        while (reader.Peek() != -1)/*�s�̖����܂œǂݍ���*/
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            CsvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
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
