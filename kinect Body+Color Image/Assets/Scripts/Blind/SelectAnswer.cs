using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnswer : MonoBehaviour
{
    public RectTransform Panel_A;
    public RectTransform Panel_B;
    public RectTransform Panel_C;
    public RectTransform Panel_D;
    
    public RectTransform CanvasTr;//�e�ɂȂ�L�����o�X

    private Vector3 LocalMousePos;//�}�E�X�̃��[�J�����W

    /*�e��p�l���̃��[�J�����W*/
    private Vector3 LocalPanelPos_A;
    private Vector3 LocalPanelPos_B;
    private Vector3 LocalPanelPos_C;
    private Vector3 LocalPanelPos_D;

    public float HoldTime;//�I������I��ł��鎞��

    private int ChoosingNum;//�I�񂾑I�����̔ԍ�

    // Start is called before the first frame update
    void Start()
    {
        HoldTime = 0;

        /*�p�l���̃��[�J�����W�擾*/
        LocalPanelPos_A = CanvasTr.InverseTransformPoint(Panel_A.position);
        LocalPanelPos_B = CanvasTr.InverseTransformPoint(Panel_B.position);
        LocalPanelPos_C = CanvasTr.InverseTransformPoint(Panel_C.position);
        LocalPanelPos_D = CanvasTr.InverseTransformPoint(Panel_D.position);

    }

    // Update is called once per frame
    void Update()
    {
        LocalMousePos = CanvasTr.InverseTransformPoint(Input.mousePosition);//�}�E�X�̃��[�J�����W�擾

        judgeHandPos();//�I�񂾑I�����̔���
    }

    private void judgeHandPos()//�肪�ǂ̑I������I��ł��邩���肷��
    {
        float PanelWidth = Panel_A.sizeDelta.x;//�e�p�l���̉����擾

        float PanelHeight = Panel_A.sizeDelta.y;//�e�p�l���̏c���擾

        /*�I�������ʕ���*/
        if (LocalMousePos.x > LocalPanelPos_A.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_A.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_A.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_A.y - PanelHeight / 2)/*����I����*/
        {
            ChoosingNum = 0;
            Debug.Log("A");
            Ansjudge();
        }
        else if (LocalMousePos.x > LocalPanelPos_B.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_B.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_B.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_B.y - PanelHeight / 2)/*�E��I����*/
        {
            ChoosingNum = 1;
            Debug.Log("B");
            Ansjudge();
        }
        else if (LocalMousePos.x > LocalPanelPos_C.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_C.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_C.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_C.y - PanelHeight / 2)/*�����I����*/
        {
            ChoosingNum = 2;
            Debug.Log("C");
            Ansjudge();
        }
        else if (LocalMousePos.x > LocalPanelPos_D.x - PanelWidth / 2 && LocalMousePos.x < LocalPanelPos_D.x + PanelWidth / 2 && LocalMousePos.y < LocalPanelPos_D.y + PanelHeight / 2 && LocalMousePos.y > LocalPanelPos_D.y - PanelHeight / 2)/*�E���I����*/
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

    private void Ansjudge()//�I�����̔���
    {
        HoldTime += Time.deltaTime;
        if(HoldTime>3.0f)//3�b�ȏ�I�������Ƃ�
        {
            switch(ChoosingNum)//�I���������̔ԍ��ɂ���ĕ���
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
