using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private float typewriterSpeed;

    [SerializeField]
    private TMP_Text nameField, dialogueField;

    private Queue<string> _sentences;

    [SerializeField]
    private Animator dialogueBoxAnimator;

    private void Start() {
        _sentences = new();
    }

    public void StartDialogue(Dialogue dialogue) {
        _sentences.Clear();

        dialogueBoxAnimator.SetBool("inDialogue", true);

        nameField.text = dialogue.Name;

        foreach (string dialogueSentence in dialogue.Sentences) {
            _sentences.Enqueue(dialogueSentence);
        }
        StopAllCoroutines();
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (_sentences.Count == 0) {
            EndDialogue();
            return;
        }
        StartCoroutine(TypeSentence(_sentences.Dequeue()));
    }

    private IEnumerator TypeSentence(string sentence) {
        dialogueField.text = "";
        foreach (char c in sentence) {
            dialogueField.text += c;
            yield return new WaitForSeconds(typewriterSpeed);
        }
    }

    private void EndDialogue() {
        Debug.Log("End Dialogue");
        dialogueBoxAnimator.SetBool("inDialogue", false);
        dialogueField.text = "";
        nameField.text = "";
    }
}