using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    public void Speak()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
