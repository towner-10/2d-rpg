using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;
    public GameObject dialogueUI;
    private TextMeshProUGUI name;
    private TextMeshProUGUI dialogueText;

    bool enabled = false;

    void Start()
    {
        name = dialogueUI.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueUI.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        dialogueUI.SetActive(false);
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if(enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        enabled = true;
        Time.timeScale = 0;
        dialogueUI.SetActive(true);
        name.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Time.timeScale = 1;
        enabled = false;
        name.text = null;
        dialogueText.text = null;
        dialogueUI.SetActive(false);
    }
}
