using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizText_SE : MonoBehaviour
{
    public AudioClip sound; //SE����

    private AudioSource audioSource; //�����R���|�[�l���g

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
