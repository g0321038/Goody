using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandUICreate : MonoBehaviour
{
    public GameObject Master;

    private int jointcount = 11;
    private Vector3 JointPosition = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        
        JointPosition = Master.GetComponent<GetInformation>().GetPosition(jointcount);

        //Debug.Log(JointPosition);

        if (JointPosition != null)
        { 
            this.transform.position = JointPosition;
        }
    }


}
