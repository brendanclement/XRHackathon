using Facebook.WitAi.Lib;
using UnityEngine;
using Unity​Engine.XR.Interaction.Toolkit;

public class ActiveSpeaker : MonoBehaviour
{
    private Speaker activeSpeaker;
    public void setSpeaker(DeactivateEventArgs args)
    {
        setSpeaker(args.interactable.gameObject);
    }

    public void setSpeaker(SelectEnterEventArgs args)
    {
        setSpeaker(args.interactable.gameObject);
    }

    public void setSpeaker(SelectExitEventArgs args)
    {
        setSpeaker(args.interactable.gameObject);
    }

    private void setSpeaker(GameObject gameObject)
    {
        gameObject.TryGetComponent(out Speaker speaker);
        activeSpeaker = speaker;
    }

    public void Speak(WitResponseNode commandResult)
    {
        activeSpeaker.Speak(commandResult);
    }

    public void ErrorSpeaking(string errorCode, string stackTrace)
    {
        activeSpeaker.OnError(errorCode, stackTrace);
    }
}
