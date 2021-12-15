using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitFPS : MonoBehaviour
{
    public int FPS;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = FPS;
    }


}
