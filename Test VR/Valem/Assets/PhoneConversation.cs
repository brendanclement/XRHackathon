using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Oculus.Voice;
using System.Collections;

public class PhoneConversation : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public AppVoiceExperience appVoiceExperience;

    public void Start(SelectEnterEventArgs args)
    {
        if (InteractorIsController(args))
        {
            Debug.LogWarning("GAME: found interactor was a controller. starting conversation with phone");
            StartCoroutine(Conversation());
            return;
        }
        Debug.LogWarning("GAME: found interactor was not a controller. not starting conversation");
    }

    public IEnumerator Conversation()
    {
        audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(2.0f);
        Debug.LogWarning("GAME: Activating wit.ai after 2 seconds");
        appVoiceExperience.ActivateImmediately();
        yield return new WaitForSeconds(2.0f);
        Debug.LogWarning("GAME: Deactivating wit.ai after 2 seconds");
        appVoiceExperience.Deactivate();
    }

    private bool InteractorIsController(SelectEnterEventArgs args)
    {
        args.interactor.TryGetComponent(out XRController controller);
        return controller != null;
    }

    public void stopSound()
    {
        audioSource.Stop();
    }
}
