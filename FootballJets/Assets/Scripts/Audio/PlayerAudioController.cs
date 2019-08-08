using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip ballHitSFX;
    public SoundPlayer soundPlayer;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            soundPlayer.PlaySound(soundSource, ballHitSFX);
        }
    }
}
