using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizText_SE : MonoBehaviour
{
    public AudioClip sound; //SE音源

    private AudioSource audioSource; //音源コンポーネント

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
