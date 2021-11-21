using UnityEngine;
using Facebook.WitAi;
using Facebook.WitAi.Lib;

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

    public void OnError(string err, string stack)
    {
        Debug.LogError("GAME: Got Error processing wit.ai " + err + stack);
        HandleUnknownIntent();
    }

    public void Speak(WitResponseNode commandResult)
    {
        string intent = commandResult.GetIntentName();
        Debug.LogError("GAME: Got intent " + commandResult.ToString());
        switch (intent)
        {
            case "get_name":
                audioSource.PlayOneShot(Name);
                break;
            case "get_relationship_to_victim":
                audioSource.PlayOneShot(Relationship);
                break;
            case "get_occupation":
                audioSource.PlayOneShot(Occupation);
                break;
            case "get_relationship_status_to_victim":
                audioSource.PlayOneShot(RelationshipStatus);
                break;
            case "get_last_contact_time_with_victim":
                audioSource.PlayOneShot(LastContactTime);
                break;
            case "get_suspected_killer":
                audioSource.PlayOneShot(SuspectedKiller);
                break;
            case "get_love_letter":
                audioSource.PlayOneShot(LoveLetter);
                break;
            case "get_poison":
                audioSource.PlayOneShot(Poison);
                break;
            case "get_will":
                audioSource.PlayOneShot(Will);
                break;
            case "get_necklace":
                audioSource.PlayOneShot(Necklace);
                break;
            default:
                HandleUnknownIntent();
                break;
        }
    }

    private void HandleUnknownIntent()
    {
        audioSource.PlayOneShot(Unknown[Random.Range(0, Unknown.Length)]);
    }
}