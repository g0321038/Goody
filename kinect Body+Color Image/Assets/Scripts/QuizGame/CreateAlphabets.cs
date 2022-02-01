using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

/*�L�����o�X��e�I�u�W�F�N�g�ɐݒ肵�ăC���X�^���X�𐶐�������*/
public class CreateAlphabets : MonoBehaviour
{
    TextAsset CsvFile;/*csv�t�@�C���Ǘ��p*/

    public List<string[]> AlphabetTabeles = new List<string[]>();/*�e�L�X�g�i�[�p�ɓ��I�ȓ񎟌��z��錾*/

    public GameObject ParentCanvas;

    public GameObject TextJudgeManager;
    private GameObject obj;

    CollectUIAlphabet script;

    public float TimeCount = 0.0f;

    public float cycle = 1.5f;

    public int LineCount = 0;/*csv�t�@�C���̍s���J�E���g�p*/

    // Start is called before the first frame update
    void Start()
    {
        obj = (GameObject)Resources.Load("Prefabs/Alphabet");
        /*�A���t�@�x�b�g�e�[�u���̃��[�h*/
        //CsvFile = Resources.Load("Texts/Quiz/Quiz1/Alphabets") as TextAsset;/*�ǂݍ���csv�t�@�C����TextAsset�Ƃ��ĊǗ�����C���[�W�H*/
        CsvFile = Resources.Load("Texts/Quiz/Quiz1/Answer_List") as TextAsset;/*�ǂݍ���csv�t�@�C����TextAsset�Ƃ��ĊǗ�����C���[�W�H*/
        StringReader reader = new StringReader(CsvFile.text);/*csv�t�@�C���̃e�L�X�g�f�[�^�擾*/

        while (reader.Peek() != -1)/*�s�̖����܂œǂݍ���*/
        {
            string line = reader.ReadLine(); // ��s���ǂݍ���
            AlphabetTabeles.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
            LineCount += 1;
            Debug.Log(line);
        }

   

        
    }

    void Update()
    {
        if (TextJudgeManager.GetComponent<JudgeText>().SceneMoveFlag != 1)
        {
            if (TimeCount > cycle)//cycle�b�����ŏo��
            {
                TimeCount = 0.0f;//�J�E���g�����Z�b�g����

                // �v���n�u�����ɃI�u�W�F�N�g�𐶐�����
                GameObject instance = (GameObject)Instantiate(obj, this.transform.position, Quaternion.identity);

                //�e�I�u�W�F�N�g���L�����o�X�ɐݒ�
                instance.transform.parent = ParentCanvas.transform;

                //�A���t�@�x�b�g�̐ݒ�
                script = instance.GetComponent<CollectUIAlphabet>();

                //�A���t�@�x�b�g�e�[�u�����當���������Ă���
                int AlphabetNum = Random.Range(0, LineCount);
                script.Alphabet = AlphabetTabeles[AlphabetNum][0];
                //Debug.Log(LineCount);

            }
            TimeCount += Time.deltaTime;
        }
    }


}
