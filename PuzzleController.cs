using UnityEngine;
using UnityEngine.Events;

public class PuzzleController:MonoBehaviour,IInteractable {
    public string promptText="Inspect";
    public string requiredAnswer;
    public string successFlag;
    public UnityEvent onSolved;
    public string Prompt=>promptText;

    public void Interact(GameObject player){Solve(requiredAnswer);}
    public void Solve(string answer){
        if(answer==requiredAnswer){
            GameState.I.SetFlag(successFlag);
            onSolved?.Invoke();
        }
    }
}
