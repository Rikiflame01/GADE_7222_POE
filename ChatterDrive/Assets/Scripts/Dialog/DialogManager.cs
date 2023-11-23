using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region InspectorItems
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI teamNumberText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueDescriptionText;
    public Image portraitImage;
    #endregion

    public Conversation conversation;

    private ADTQueue<DialogueItem> dialogueQueue;
    private Dictionary<Speaker, Image> speakerPortraitsCache;
    SFXManager SFXManager;

    #region UnityMethods
    void Start()
    {
        InitializeDialogueQueue();
        DisplayNextDialogue();
    }
    #endregion

    #region PrivateMethods
    private void InitializeDialogueQueue()
    {
        speakerPortraitsCache = new Dictionary<Speaker, Image>();
        dialogueQueue = new ADTQueue<DialogueItem>();

        foreach (var item in conversation.dialogueItems)
        {
            dialogueQueue.Enqueue(item);
            CacheSpeakerPortrait(item.speaker);
        }
    }

    private void CacheSpeakerPortrait(Speaker speaker)
    {
        if (!speakerPortraitsCache.ContainsKey(speaker))
        {
            speakerPortraitsCache[speaker] = speaker.portraitPrefab.GetComponent<Image>();
        }
    }

    private void UpdateDialogueUI(DialogueItem item)
    {
        nameText.text = item.speaker.speakerName;
        teamNumberText.text = item.speaker.teamNumber;
        dialogueText.text = item.dialogue;
        dialogueDescriptionText.text = item.dialogueDescription;

        if (speakerPortraitsCache.TryGetValue(item.speaker, out Image speakerImage))
        {
            portraitImage.sprite = speakerImage.sprite;
        }
    }

    private void HandleEmptyQueue()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "CheckpointRaceDialogue")
        {
            SceneManager.LoadScene("CheckpointRace");
        }
        else if (currentSceneName == "BeginnerRaceDialogue")
        {
            SceneManager.LoadScene("BeginnerRace");
        }
        else if (currentSceneName == "AdvancedRaceDialogue")
        {
            SceneManager.LoadScene("AdvancedRace");
        }
        else
        {
            throw new InvalidOperationException("Queue is empty");
        }
    }
    #endregion

    #region PublicMethods
    public void DisplayNextDialogue()
    {
        SFXManager.Instance.PlaySound("NextDialog");
        try
        {
            DialogueItem item = dialogueQueue.Dequeue();
            UpdateDialogueUI(item);
        }
        catch (Exception)
        {
            HandleEmptyQueue(); //Change scene when queue is empty.
            return;
        }
    }
    #endregion
}
