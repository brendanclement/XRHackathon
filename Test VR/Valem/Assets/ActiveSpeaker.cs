using Facebook.WitAi.Lib;
using UnityEngine;
using Unity​Engine.XR.Interaction.Toolkit;

public class ActiveSpeaker : MonoBehaviour
{
    private NPCSpeak activeSpeaker;
    public void setSpeaker(DeactivateEventArgs args)
    {
        activeSpeaker = args.interactable.gameObject.GetComponent<NPCSpeak>();
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
