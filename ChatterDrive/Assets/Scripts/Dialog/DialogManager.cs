using TMPro;
using UnityEngine;
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
        if (dialogueQueue.Peek() != null)
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
    }
}
