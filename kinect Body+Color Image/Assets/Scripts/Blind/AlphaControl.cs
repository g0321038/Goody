using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour
{
    private GameObject ParentCanvas;//ブラックパネルの親オブジェクトとなるキャンバス
    private RectTransform CanvasTr;//親キャンバスの空間上データ
    
    private Vector3 LocalMousePos;//マウスのローカル座標

    public GameObject BlackPanel;//透過するパネル
    public RectTransform BP_Tr;//透過するパネルの空間上データ

    private Image PanelImg;//パネルのイメージコンポーネント

    private Texture2D PanelTex;//パネルイメージのテクスチャデータ

    List<Color> texturePixelList;//現在のテクスチャのピクセルリスト

    private SpotLight spotlight;

    private BlackBlush blackblush;

    private Vector3 JointPosition;
    private int JointCount = 11;
    private GameObject KinectInfo;

    // Start is called before the first frame update
    void Start()
    {
        ParentCanvas = GameObject.Find("QuizPanel");//QuizPanelを親オブジェクトにするため検索
        CanvasTr = ParentCanvas.GetComponent<RectTransform>();//親オブジェクトのデータ取得

        BlackPanel = GameObject.Find("BlackPanel");//一部を透明にする対象のパネルオブジェクト取得
        PanelImg = BlackPanel.GetComponent<Image>();//パネルオブジェクトのイメージデータ取得
        BP_Tr = BlackPanel.GetComponent<RectTransform>();//パネルオブジェクトの空間データ取得

        KinectInfo = GameObject.Find("KinectInfo");//kinect情報取得用

        int width = (int)BP_Tr.sizeDelta.x;
        int height = (int)BP_Tr.sizeDelta.y;

        spotlight = new SpotLight();

        PanelTex =PanelImg.sprite.texture;//テクスチャデータの取得

        /*テクスチャを黒く塗りつぶす（初期化）*/
        blackblush = new BlackBlush(width, height);

        PanelImg.sprite.texture.SetPixels(0,0,(int)BP_Tr.sizeDelta.x, (int)BP_Tr.sizeDelta.y, blackblush.colors);

        PanelImg.sprite.texture.Apply();


  
    }

    // Update is called once per frame
    void Update()
    {
        //JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));

        //PanelImg.sprite.texture.SetPixels(0, 0, (int)BP_Tr.sizeDelta.x, (int)BP_Tr.sizeDelta.y, blackblush.colors);//テクスチャの初期化

        //float width = BP_Tr.sizeDelta.x;
        //float height = BP_Tr.sizeDelta.y;

        //if (JointPosition.x < width / 2 - spotlight.blockWidth / 2 && JointPosition.x > -1 * width / 2 + spotlight.blockWidth / 2 && JointPosition.y < height / 2 - spotlight.blockHeight / 2 && JointPosition.y > -1 * height / 2 + spotlight.blockWidth / 2)/*マウスがウィンドウ内にいる&スポットライトの半径一回り分内側にいる場合*/
        //{

        //    PanelImg.sprite.texture.SetPixels((int)JointPosition.x + (int)width / 2 - spotlight.blockWidth / 2, (int)JointPosition.y + (int)height / 2 - spotlight.blockHeight / 2, spotlight.blockWidth, spotlight.blockHeight, spotlight.colors);

        //    PanelImg.sprite.texture.Apply();

        //}

        JointPosition = Vector3.Scale(KinectInfo.GetComponent<GetInformation>().GetPosition(JointCount), new Vector3(250, 150, 1));

        PanelImg.sprite.texture.SetPixels(0, 0, (int)BP_Tr.sizeDelta.x, (int)BP_Tr.sizeDelta.y, blackblush.colors);//テクスチャの初期化

        float width = BP_Tr.sizeDelta.x, height = BP_Tr.sizeDelta.y;

        int TextureX = (int)JointPosition.x + (int)PanelTex.width / 2;//テクスチャ座標は左下が(0,0)なのでマウスの座標と変換する

        int TextureY = (int)JointPosition.y + (int)PanelTex.height / 2;//テクスチャ座標は左下が(0,0)なのでマウスの座標と変換する

        /*照らす範囲1ピクセルずつの透過処理*/
        for (int y = -1 * spotlight.blockHeight / 2; y < spotlight.blockHeight / 2; y++)
        {
            for (int x = -1 * spotlight.blockWidth / 2; x < spotlight.blockWidth / 2; x++)
            {
                /*テクスチャに対して左側もしくは右側にはみ出さない部分だけ処理*/
                if (TextureX + x > 0 && TextureX + x < width && TextureY + y > 0 && TextureY + y < height)
                {
                    PanelTex.SetPixel(TextureX + x, TextureY + y, new Color(0.0f, 0.0f, 0.0f, 0.0f));
                }
            }
        }

        PanelImg.sprite.texture.Apply();
    }
    private class BlackBlush/*テクスチャの全体を黒く染める用のブラシクラス*/
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

    
    private class SpotLight/*テクスチャの一部を透過する際の透過領域制御用クラス*/
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
