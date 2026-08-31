using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ETLRState {
    public int room=1, phase=1, face=1;
    public string gender="boy";
    public float timeRemaining=600;
    public List<string> flags=new List<string>();
    public List<string> secrets=new List<string>();
}

public class GameState:MonoBehaviour {
    public static GameState I {get; private set;}
    public ETLRState Data=new ETLRState();

    void Awake() {
        if(I!=null && I!=this){Destroy(gameObject);return;}
        I=this; DontDestroyOnLoad(gameObject); Load();
    }

    public void SetCharacter(string gender,int face){Data.gender=gender;Data.face=face;Save();}
    public bool HasFlag(string id)=>Data.flags.Contains(id);
    public void SetFlag(string id){if(!Data.flags.Contains(id))Data.flags.Add(id);Save();}
    public void EnterRoom(int room){
        Data.room=Mathf.Clamp(room,1,50);
        Data.phase=((room-1)/10)+1;
        Data.timeRemaining=Mathf.Max(150,600-(Data.phase-1)*45);
        Save();
    }
    public void Save(){PlayerPrefs.SetString("ETLR_STATE",JsonUtility.ToJson(Data));PlayerPrefs.Save();}
    public void Load(){if(PlayerPrefs.HasKey("ETLR_STATE"))Data=JsonUtility.FromJson<ETLRState>(PlayerPrefs.GetString("ETLR_STATE"));}
}
