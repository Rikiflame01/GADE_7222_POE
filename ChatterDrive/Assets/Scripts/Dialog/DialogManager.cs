using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI teamNumberText;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialogueDescriptionText;

    public Image portraitImage;
    public Conversation conversation;

    private ADTQueue<DialogueItem> dialogueQueue;
    private Image cachedSpeakerImage;

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
        catch (InvalidOperationException)
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
}
