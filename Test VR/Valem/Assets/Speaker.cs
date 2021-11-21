using Facebook.WitAi.Lib;

public interface Speaker
{
    public void Speak(WitResponseNode commandResult);
    public void OnError(string error, string stackTrace);
}
