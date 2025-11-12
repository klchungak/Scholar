using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip eatClip;
    
    // Start is called before the first frame update
    void Start()
    {
        // Validate required components
        if (audioPlayer == null)
        {
            Debug.LogError("AudioSource is not assigned in GameAudio!");
        }
        
        if (eatClip == null)
        {
            Debug.LogWarning("EatClip is not assigned in GameAudio!");
        }
    }

    public void ReplayBackgroundMusic()
    {
        if (audioPlayer != null)
        {
            audioPlayer.Play();
        }
        else
        {
            Debug.LogError("Cannot play background music: AudioSource is null!");
        }
    }
    
    public void PlayEatSound()
    {
        if (audioPlayer != null && eatClip != null)
        {
            audioPlayer.PlayOneShot(eatClip);
        }
        else
        {
            Debug.LogWarning("Cannot play eat sound: AudioSource or EatClip is null!");
        }
    }
}