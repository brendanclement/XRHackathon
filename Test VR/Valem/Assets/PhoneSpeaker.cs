using Facebook.WitAi;
using Facebook.WitAi.Lib;
using Oculus.Voice;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PhoneSpeaker : MonoBehaviour, Speaker
{
    public AppVoiceExperience appVoiceExperience;
    public AudioSource audioSource;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;
    public AudioClip[] misunderstoodClips;

    public void OnError(string error, string stackTrace)
    {
        StartNewConversation();
    }

    public void Speak(WitResponseNode commandResult)
    {
        string intent = commandResult.GetIntentName();
        Debug.LogWarning("GAME: Phonespeaker - Got intent " + commandResult.ToString());
        Debug.LogWarning("GAME: PhoneSpeaker - is intent: " + intent);
        switch (intent)
        {
            case "suspect_george":
                PlayerWins();
                return;
            case "suspect_mary":
            case "suspect_julia":
            case "suspect_bella":
                PlayerLoses();
                return;
            default:
                break;
        }

        StartNewConversation();
    }

    private void PlayerLoses()
    {
        // Do something when the player loses
        SceneManager.LoadScene("Game Lost");
        Debug.LogWarning("GAME: Player loses");
    }

    private void PlayerWins()
    {
        // Do something when the player wins
        SceneManager.LoadScene("Game Won");
        Debug.LogWarning("GAME: Player wins");
    }

    private IEnumerable StartNewConversation()
    {
        Debug.LogWarning("GAME: Starting a new conversation");
        audioSource.PlayOneShot(misunderstoodClips[Random.Range(0, misunderstoodClips.Length)]);
        yield return new WaitForSeconds(2.0f);
        appVoiceExperience.ActivateImmediately();
        yield return new WaitForSeconds(2.0f);
        appVoiceExperience.Deactivate();
    }
}
