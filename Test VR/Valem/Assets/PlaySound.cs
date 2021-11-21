using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public void play(SelectEnterEventArgs args)
    {
        XRController controller;

        args.interactor.TryGetComponent<XRController>(out controller);
        if (controller != null)
        {
            audioSource.PlayOneShot(sound);
        }
        
    }

    public void stopSound()
    {
        audioSource.Stop();
    }
}
