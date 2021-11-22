using UnityEngine;
using Facebook.WitAi;
using Facebook.WitAi.Lib;
using System.Collections;
using System.Collections.Generic;

public class NPCSpeak : MonoBehaviour, Speaker
{
    public AudioSource audioSource;
    public AudioClip Name;
    public AudioClip Relationship;
    public AudioClip Occupation;
    public AudioClip RelationshipStatus;
    public AudioClip LastContactTime;
    public AudioClip SuspectedKiller;
    public AudioClip LoveLetter;
    public AudioClip Poison;
    public AudioClip Will;
    public AudioClip Necklace;
    public AudioClip Summary;
    public AudioClip Victim;
    public AudioClip Alibi;
    public AudioClip[] Unknown;
    public Animator anim;

    public void OnError(string err, string stack)
    {
        Debug.LogError("GAME: Got Error processing wit.ai " + err + stack);
        HandleUnknownIntent();
    }

    public void Speak(WitResponseNode commandResult)
    {
        string intent = commandResult.GetIntentName();
        Debug.Log("GAME: Got intent " + commandResult.ToString());
        switch (intent)
        {
            case "get_name":
                AnimateAndPlayAudio(Name);
                break;
            case "get_relationship_to_victim":
                AnimateAndPlayAudio(Relationship);
                break;
            case "get_occupation":
                AnimateAndPlayAudio(Occupation);
                break;
            case "get_relationship_status_to_victim":
                AnimateAndPlayAudio(RelationshipStatus);
                break;
            case "get_last_contact_time_with_victim":
                AnimateAndPlayAudio(LastContactTime);
                break;
            case "get_suspected_killer":
                AnimateAndPlayAudio(SuspectedKiller);
                break;
            case "get_love_letter":
                AnimateAndPlayAudio(LoveLetter);
                break;
            case "get_poison":
                AnimateAndPlayAudio(Poison);
                break;
            case "get_will":
                AnimateAndPlayAudio(Will);
                break;
            case "get_necklace":
                AnimateAndPlayAudio(Necklace);
                break;
            case "get_summary":
                AnimateAndPlayAudio(Summary);
                break;
            case "get_victim":
                AnimateAndPlayAudio(Victim);
                break;
            case "get_alibi":
                AnimateAndPlayAudio(Alibi);
                break;
            default:
                HandleUnknownIntent();
                break;
        }
    }

    private void AnimateAndPlayAudio(AudioClip clip)
    {
        anim.SetBool("isTalking", true);
        audioSource.PlayOneShot(clip);
        StartCoroutine(TurnOffAnimation(clip.length));
    }

    private IEnumerator TurnOffAnimation(float after)
    {
        yield return new WaitForSeconds(after);
        anim.SetBool("isTalking", false);
    }

    private void HandleUnknownIntent()
    {
        AudioClip clip = Unknown[Random.Range(0, Unknown.Length)];
        AnimateAndPlayAudio(clip);
    }
}