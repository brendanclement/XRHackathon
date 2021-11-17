using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.WitAi;
using Facebook.WitAi.Lib;

public class NPCSpeak : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public AudioClip errorAudio;

    // Start is called before the first frame update
    public void Speak(WitResponseNode commandResult)
    {
        string intent = commandResult.GetIntentName();
        Debug.LogError("GAME: Got intent " + commandResult.ToString());
        if (intent == "get_name")
        {
            audioSource.PlayOneShot(audioClip2);
        } 
        else
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void OnError(string somethiing, string somethingElse)
    {
        Debug.LogError("GAME: Got Error processing wit.ai " + somethingElse + somethiing);
        audioSource.PlayOneShot(errorAudio);
    }
}
