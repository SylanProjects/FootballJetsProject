using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip soundEffect;

    public AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        soundSource.clip = soundEffect;
    }

    // Update is called once per frame
    public void Play() {
        soundSource.Play();
    
    }
}
