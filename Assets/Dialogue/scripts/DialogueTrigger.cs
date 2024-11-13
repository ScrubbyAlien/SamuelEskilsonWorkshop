using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue Dialogue;

    public void StartDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

    public void EndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
