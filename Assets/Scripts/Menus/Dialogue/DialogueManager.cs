using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;
    public GameObject dialogueUI;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;

    bool dialogueEnabled = false;

    void Start()
    {
        nameText = dialogueUI.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueUI.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        dialogueUI.SetActive(false);
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if(dialogueEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueEnabled = true;
        Time.timeScale = 0;
        dialogueUI.SetActive(true);
        nameText.text = dialogue.name;

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
        dialogueEnabled = false;
        nameText.text = null;
        dialogueText.text = null;
        dialogueUI.SetActive(false);
    }
}
