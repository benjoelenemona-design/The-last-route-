using UnityEngine;

public class TensionDirector:MonoBehaviour {
    public AudioSource music, heartbeat, breathing;
    public float maxTime=600;

    void Update(){
        if(GameState.I==null)return;
        float t=GameState.I.Data.timeRemaining;
        float panic=1-Mathf.Clamp01(t/maxTime);
        if(music)music.volume=Mathf.Lerp(.2f,.95f,panic);
        if(heartbeat)heartbeat.volume=Mathf.Lerp(0,.9f,Mathf.InverseLerp(90,0,t));
        if(breathing)breathing.volume=Mathf.Lerp(.05f,.8f,panic);
    }
}
