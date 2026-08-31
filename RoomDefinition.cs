using UnityEngine;

[CreateAssetMenu(menuName="ETLR/Room Definition")]
public class RoomDefinition:ScriptableObject {
    public int roomNumber;
    public string title;
    [TextArea] public string objective;
    [TextArea] public string clueText;
    public string[] requiredFlags;
    public string successFlag;
    public string[] consequenceFlags;
    public bool hasNPC, hasTimer;
    public AudioClip calmMusic, tensionMusic;
}
