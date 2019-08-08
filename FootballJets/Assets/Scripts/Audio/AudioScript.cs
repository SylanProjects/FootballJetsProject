using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip soundEffect;
    public AudioSource soundSource;
    void Start()
    {
        soundSource.clip = soundEffect;
    }

    public void Play() {
        soundSource.Play();
    }
}
