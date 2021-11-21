using UnityEngine;
using Facebook.WitAi;
using Facebook.WitAi.Lib;
using System.Collections;

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
    public AudioClip[] Unknown;
    public Animator anim;

    public void OnError(string err, string stack)
    {
        Debug.LogError("GAME: Got Error processing wit.ai " + err + stack);
        HandleUnknownIntent();
    }

    private IEnumerator Speak(float length)
    {
       
        yield return new WaitForSeconds(length);

        anim.SetBool("isTalking", false);
    }


    public void Speak(WitResponseNode commandResult)
    {
        string intent = commandResult.GetIntentName();
        Debug.LogError("GAME: Got intent " + commandResult.ToString());
        switch (intent)
        {
            case "get_name":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(Name);
                StartCoroutine(Speak(Name.length));
                break;
            case "get_relationship_to_victim":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(Relationship);
                StartCoroutine(Speak(Relationship.length));
                break;
            case "get_occupation":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(Occupation);
                StartCoroutine(Speak(Occupation.length));
                break;
            case "get_relationship_status_to_victim":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(RelationshipStatus);
                StartCoroutine(Speak(RelationshipStatus.length));
                break;
            case "get_last_contact_time_with_victim":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(LastContactTime);
                StartCoroutine(Speak(LastContactTime.length)); ;
                break;
            case "get_suspected_killer":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(SuspectedKiller);
                StartCoroutine(Speak(SuspectedKiller.length));
                break;
            case "get_love_letter":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(LoveLetter);
                StartCoroutine(Speak(LoveLetter.length));
                break;
            case "get_poison":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(Poison);
                StartCoroutine(Speak(Poison.length));
                break;
            case "get_will":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(Will);
                StartCoroutine(Speak(Will.length));
                break;
            case "get_necklace":
                anim.SetBool("isTalking", true);
                audioSource.PlayOneShot(Necklace);
                StartCoroutine(Speak(Necklace.length));
                break;
            default:
                HandleUnknownIntent();
                break;
        }
    }

    private void HandleUnknownIntent()
    {
        anim.SetBool("isTalking", true);
        AudioClip clip = Unknown[Random.Range(0, Unknown.Length)];
        audioSource.PlayOneShot(clip);
        StartCoroutine(Speak(clip.length));
    }
}