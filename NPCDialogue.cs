using UnityEngine;
using UnityEngine.Events;

public class NPCDialogue:MonoBehaviour,IInteractable {
    public string promptText="Talk";
    [TextArea] public string[] lines;
    public UnityEvent onConversationComplete;
    public string Prompt=>promptText;

    public void Interact(GameObject player){
        foreach(var line in lines)Debug.Log("[NPC] "+line);
        onConversationComplete?.Invoke();
    }
}
