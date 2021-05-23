﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager_2 : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject DialogueBox; 
    public Text DialogueText;
    [HideInInspector]
    public bool SwitchScene;


    private Queue<string> sentences;
    private string DialogueName;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        SwitchScene = false;
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager_2>().StartDialogue(dialogue);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        //Debug.Log("Sentence Count 1: " + sentences.Count);
        sentences.Clear();
        DialogueName = dialogue.name;
        DialogueBox.SetActive(true);
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        //int sentenceNumber = sentences.Count;

        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        //Debug.Log("Sentence Count 5: " + sentences.Count);
        if (sentences.Count == 0){
            //Debug.Log("Sentence Count 2: " + sentences.Count);
            EndDialogue();
            return;
        }
        //sentenceNumber -= 1;
        //Debug.Log("Sentence Count 3: " + sentences.Count);
        string sentence = sentences.Dequeue();
        //Debug.Log("Sentence Count after Dequeue: " + sentences.Count);
        Debug.Log(sentence);
        DialogueText.text = DialogueName.ToUpper() + ": " + sentence;

    }

    void EndDialogue()
    {
        //Debug.Log("Sentence Count 4: " + sentences.Count);
        Debug.Log("End of conversation.");
        //DialogueBox.GetComponent<Renderer>().enabled = false;
        DialogueBox.SetActive(false);
        if (SwitchScene == true) {
            //SceneManager.LoadScene(2);
            FindObjectOfType<LevelChanger>().FadeToLevel(3);
        } 
        if (FindObjectOfType<DialogueTrigger_2_2>().TriggeredIsabelle == true){
            FindObjectOfType<DialogueTrigger_2_2>().MoveIsabelle = true;
        }
        if (FindObjectOfType<DialogueTrigger_2_3>().TriggeredKidSam == true)
        {
            FindObjectOfType<DialogueTrigger_2_3>().MoveKidSam = true;
        }
        if (FindObjectOfType<DialogueTrigger_2_4>().TriggeredKidAndrew == true)
        {
            FindObjectOfType<DialogueTrigger_2_4>().MoveKidAndrew = true;
        }
        if (FindObjectOfType<DialogueTrigger_2_5>().TriggeredPanda == true)
        {
            FindObjectOfType<DialogueTrigger_2_5>().MovePanda = true;
        }

    }
   
}