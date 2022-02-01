using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnswer : MonoBehaviour
{
    public RectTransform Panel_A;
    public RectTransform Panel_B;
    public RectTransform Panel_C;
    public RectTransform Panel_D;
    
    public RectTransform CanvasTr;//親になるキャンバス

    private Vector3 LocalMousePos;//マウスのローカル座標

    /*各種パネルのローカル座標*/
    private Vector3 LocalPanelPos_A;
    private Vector3 LocalPanelPos_B;
    private Vector3 LocalPanelPos_C;
    private Vector3 LocalPanelPos_D;

    public float HoldTime;//選択肢を選んでいる時間

    private int ChoosingNum;//選んだ選択肢の番号

    // Start is called before the first frame update
    void Start()
    {
        HoldTime = 0;

        /*パネルのローカル座標取得*/
        LocalPanelPos_A = CanvasTr.InverseTransformPoint(Panel_A.position);
        LocalPanelPos_B = CanvasTr.InverseTransformPoint(Panel_B.position);
        LocalPanelPos_C = CanvasTr.InverseTransformPoint(Panel_C.position);
        LocalPanelPos_D = CanvasTr.InverseTransformPoint(Panel_D.position);

    }

    // Update is called once per frame
    void Update()
    {
        LocalMousePos = CanvasTr.InverseTransformPoint(Input.mousePosition);//マウスのローカル座標取得

        judgeHandPos();//選んだ選択肢の判定
    }

    private void judgeHandPos()//手がどの選択肢を選んでいるか判定する
    {
        float PanelWidth = Panel_A.sizeDelta.x;//各パネルの横幅取得

        float PanelHeight = Panel_A.sizeDelta.y;//各パネルの縦幅取得

        /*選択肢判別部分*/
        if (LocalMousePos.x > LocalPanelPos_A.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_A.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_A.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_A.y - PanelHeight / 2)/*左上選択肢*/
        {
            ChoosingNum = 0;
            Debug.Log("A");
            Ansjudge();
        }
        else if (LocalMousePos.x > LocalPanelPos_B.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_B.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_B.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_B.y - PanelHeight / 2)/*右上選択肢*/
        {
            ChoosingNum = 1;
            Debug.Log("B");
            Ansjudge();
        }
        else if (LocalMousePos.x > LocalPanelPos_C.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_C.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_C.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_C.y - PanelHeight / 2)/*左下選択肢*/
        {
            ChoosingNum = 2;
            Debug.Log("C");
            Ansjudge();
        }
        else if (LocalMousePos.x > LocalPanelPos_D.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_D.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_D.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_D.y - PanelHeight / 2)/*右下選択肢*/
        {
            ChoosingNum = 3;
            Debug.Log("D");
            Ansjudge();
        }
        else
        {
            HoldTime = 0;
        }
    }

    private void Ansjudge()//選択肢の判定
    {
        HoldTime += Time.deltaTime;
        if(HoldTime>3.0f)//3秒以上選択したとき
        {
            switch(ChoosingNum)//選択した国の番号によって分岐
            {
                case 0:
                    Debug.Log("You choosed Ans A");
                    break;
                case 1:
                    Debug.Log("You choosed Ans B");
                    break;
                case 2:
                    Debug.Log("You choosed Ans C");
                    break;
                case 3:
                    Debug.Log("You choosed Ans D");
                    break;
            }
        }

    }
}
