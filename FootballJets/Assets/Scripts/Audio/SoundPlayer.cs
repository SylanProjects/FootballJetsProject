using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void PlaySound(AudioSource soundSource, AudioClip audioC)
    {
        soundSource.clip = audioC;
        soundSource.Play();
    }
}
