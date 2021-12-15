using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    PointerEventData pointer;
    bool UItouchFlag=false;

    // Start is called before the first frame update
    void Start()
    {
        pointer = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        List<RaycastResult> results = new List<RaycastResult>();//UI�T�����ʊi�[�p

        pointer.position = Input.mousePosition;//�}�E�X�|�C���^�̕����Ƀ��C���΂�
        EventSystem.current.RaycastAll(pointer, results);//���C��ɂ���UI��result�Ɋi�[

        //if (results == null) Debug.Log("aaa");
        
        foreach (RaycastResult target in results)
        {
            UItouchFlag = true;
            target.gameObject.GetComponent<Image>().color = new Color32(242, 108, 216, 255);
            Debug.Log(target.gameObject.name);
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("aaa");
        }
    }
}
