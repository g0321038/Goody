using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour
{
    private GameObject ParentCanvas;//�u���b�N�p�l���̐e�I�u�W�F�N�g�ƂȂ�L�����o�X
    private RectTransform CanvasTr;//�e�L�����o�X�̋�ԏ�f�[�^
    
    private Vector3 LocalMousePos;//�}�E�X�̃��[�J�����W

    public GameObject BlackPanel;//���߂���p�l��
    public RectTransform BP_Tr;//���߂���p�l���̋�ԏ�f�[�^

    private Image PanelImg;//�p�l���̃C���[�W�R���|�[�l���g

    private Texture2D PanelTex;//�p�l���C���[�W�̃e�N�X�`���f�[�^

    List<Color> texturePixelList;//���݂̃e�N�X�`���̃s�N�Z�����X�g

    private SpotLight spotlight;

    private BlackBlush blackblush;

    private Vector3 JointPosition;
    private int JointCount = 11;
    private GameObject KinectInfo;

    // Start is called before the first frame update
    void Start()
    {
        ParentCanvas = GameObject.Find("QuizPanel");//QuizPanel��e�I�u�W�F�N�g�ɂ��邽�ߌ���
        CanvasTr = ParentCanvas.GetComponent<RectTransform>();//�e�I�u�W�F�N�g�̃f�[�^�擾

        BlackPanel = GameObject.Find("BlackPanel");//�ꕔ�𓧖��ɂ���Ώۂ̃p�l���I�u�W�F�N�g�擾
        PanelImg = BlackPanel.GetComponent<Image>();//�p�l���I�u�W�F�N�g�̃C���[�W�f�[�^�擾
        BP_Tr = BlackPanel.GetComponent<RectTransform>();//�p�l���I�u�W�F�N�g�̋�ԃf�[�^�擾

        KinectInfo = GameObject.Find("KinectInfo");//kinect���擾�p

        int width = (int)BP_Tr.sizeDelta.x;
        int height = (int)BP_Tr.sizeDelta.y;

        spotlight = new SpotLight();

        PanelTex =PanelImg.sprite.texture;//�e�N�X�`���f�[�^�̎擾

        /*�e�N�X�`���������h��Ԃ��i�������j*/
        blackblush = new BlackBlush(width, height);

        PanelImg.sprite.texture.SetPixels(0,0,(int)BP_Tr.sizeDelta.x, (int)BP_Tr.sizeDelta.y, blackblush.colors);

        PanelImg.sprite.texture.Apply();


  
    }

    // Update is called once per frame
    void Update()
    {
        //JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));

        //PanelImg.sprite.texture.SetPixels(0, 0, (int)BP_Tr.sizeDelta.x, (int)BP_Tr.sizeDelta.y, blackblush.colors);//�e�N�X�`���̏�����

        //float width = BP_Tr.sizeDelta.x;
        //float height = BP_Tr.sizeDelta.y;

        //if (JointPosition.x < width / 2 - spotlight.blockWidth / 2 && JointPosition.x > -1 * width / 2 + spotlight.blockWidth / 2 && JointPosition.y < height / 2 - spotlight.blockHeight / 2 && JointPosition.y > -1 * height / 2 + spotlight.blockWidth / 2)/*�}�E�X���E�B���h�E���ɂ���&�X�|�b�g���C�g�̔��a���蕪�����ɂ���ꍇ*/
        //{

        //    PanelImg.sprite.texture.SetPixels((int)JointPosition.x + (int)width / 2 - spotlight.blockWidth / 2, (int)JointPosition.y + (int)height / 2 - spotlight.blockHeight / 2, spotlight.blockWidth, spotlight.blockHeight, spotlight.colors);

        //    PanelImg.sprite.texture.Apply();

        //}

        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));

        PanelImg.sprite.texture.SetPixels(0, 0, (int)BP_Tr.sizeDelta.x, (int)BP_Tr.sizeDelta.y, blackblush.colors);//�e�N�X�`���̏�����

        float width = BP_Tr.sizeDelta.x, height = BP_Tr.sizeDelta.y;

        int TextureX = (int)JointPosition.x + (int)PanelTex.width / 2;//�e�N�X�`�����W�͍�����(0,0)�Ȃ̂Ń}�E�X�̍��W�ƕϊ�����

        int TextureY = (int)JointPosition.y + (int)PanelTex.height / 2;//�e�N�X�`�����W�͍�����(0,0)�Ȃ̂Ń}�E�X�̍��W�ƕϊ�����

        /*�Ƃ炷�͈�1�s�N�Z�����̓��ߏ���*/
        for (int y = -1 * spotlight.blockHeight / 2; y < spotlight.blockHeight / 2; y++)
        {
            for (int x = -1 * spotlight.blockWidth / 2; x < spotlight.blockWidth / 2; x++)
            {
                /*�e�N�X�`���ɑ΂��č����������͉E���ɂ͂ݏo���Ȃ�������������*/
                if (TextureX + x > 0 && TextureX + x < width && TextureY + y > 0 && TextureY + y < height)
                {
                    PanelTex.SetPixel(TextureX + x, TextureY + y, new Color(0.0f, 0.0f, 0.0f, 0.0f));
                }
            }
        }

        PanelImg.sprite.texture.Apply();
    }
    private class BlackBlush/*�e�N�X�`���̑S�̂��������߂�p�̃u���V�N���X*/
    {
        public AlphaControl alphacontrol;
        public Color color;
        public Color[] colors;
        public BlackBlush(int width,int height)
        {
            colors = new Color[width*height];
            for(int i=0;i<colors.Length;i++)
            {
                colors[i] = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            }

        }
    }

    
    private class SpotLight/*�e�N�X�`���̈ꕔ�𓧉߂���ۂ̓��ߗ̈搧��p�N���X*/
    {
        public int blockWidth = 400;
        public int blockHeight = 400;
        public Color color;
        public Color[] colors;

        public SpotLight()
        {
            colors = new Color[blockWidth * blockHeight];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = new Color(0.0f,0.0f,0.0f,0.0f);
            }
        }
    }


}
