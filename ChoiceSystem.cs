using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class ChoiceOption {
    public string label;
    public string consequenceFlag;
    public float timeCost;
}

public class ChoiceSystem:MonoBehaviour {
    public ChoiceOption[] options;
    public UnityEvent onChoiceMade;

    public void Choose(int index){
        if(index<0||index>=options.Length)return;
        var o=options[index];
        if(!string.IsNullOrEmpty(o.consequenceFlag))GameState.I.SetFlag(o.consequenceFlag);
        GameState.I.Data.timeRemaining=Mathf.Max(0,GameState.I.Data.timeRemaining-o.timeCost);
        GameState.I.Save();
        onChoiceMade?.Invoke();
    }
}
