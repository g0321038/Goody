using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrackingUI : MonoBehaviour
{
    private GameObject obj;
    private GameObject Master;
    private object UI;
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
        GameObject Master = GameObject.Find("Master");
        bool Tracked = Master.GetComponent<GetInformation>().GetTracked();
        if (Tracked == true)
        {
            if (UI != null)
            {
                UI = Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            }
        }
    }
}
