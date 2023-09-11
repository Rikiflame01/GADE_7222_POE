using System;
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
    private Image cachedSpeakerImage;


    #region UnityMethods
    void Start()
    {
        dialogueQueue = new ADTQueue<DialogueItem>();
        foreach (var item in conversation.dialogueItems)
        {
            dialogueQueue.Enqueue(item);
        }

        if (conversation.dialogueItems.Count > 0)
        {
            cachedSpeakerImage = conversation.dialogueItems[0].speaker.portraitPrefab.GetComponent<Image>();
        }

        DisplayNextDialogue();
    }
    #endregion

    #region Methods
    public void DisplayNextDialogue()
    {
        try
        {
            DialogueItem item = dialogueQueue.Dequeue();
            nameText.text = item.speaker.speakerName;
            teamNumberText.text = item.speaker.teamNumber;
            dialogueText.text = item.dialogue;
            dialogueDescriptionText.text = item.dialogueDescription;

            if (cachedSpeakerImage != null)
            {
                portraitImage.sprite = cachedSpeakerImage.sprite;
            }
        }
        catch (InvalidOperationException) // If the queue is empty it will throw an error,
                                          // this code catches it and changes the scene depending on the current scene name.
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            if (currentSceneName == "CheckpointRaceDialogue")
            {
                SceneManager.LoadScene("CheckpointRace");
            }
            else if (currentSceneName == "Beginner Race Dialogue")
            {
                throw new InvalidOperationException("Not Implemented");
            }
            else if (currentSceneName == "Advanced Race Dialogue")
            {
                throw new InvalidOperationException("Not Implemented");
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }
    }
    #endregion
}
