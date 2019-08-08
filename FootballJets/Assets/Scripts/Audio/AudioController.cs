using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource soundSource;
    public AudioClip wallHitSfx;
    public AudioClip goalScore;
    public SoundPlayer soundPlayer;
 
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftGoal") || other.gameObject.CompareTag("RightGoal"))
        {
            soundPlayer.PlaySound(soundSource, goalScore);
        }
       
        if (other.gameObject.CompareTag("Wall"))
        {
            soundPlayer.PlaySound(soundSource, wallHitSfx);
        }
    }
    
}
