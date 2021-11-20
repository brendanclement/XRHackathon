using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public void play()
    {
        audioSource.PlayOneShot(sound);
    }
}
