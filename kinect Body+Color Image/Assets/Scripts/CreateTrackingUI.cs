using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrackingUI : MonoBehaviour
{
    private GameObject obj;
    private GameObject Master;
    private bool Flag = true;
    // ������
    void Start()
    {
        // Resources�t�H���_����Cube�v���n�u�̃I�u�W�F�N�g���擾
        obj = (GameObject)Resources.Load("RightHand");
        Master = GameObject.Find("Master");
        //Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    void Update()
    {
        //�{�f�B�g���b�L���O����Ă��邩���Ȃ���

        bool Tracked = Master.GetComponent<GetInformation>().GetTracked();
        
        if (Tracked == true)
        {
            if (Flag == true)
            {
                Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                Flag = false;
            }
        }
    }
}
