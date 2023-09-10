using TMPro;
using UnityEngine;
using UnityEngine.UI; // Required for the Image component

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portraitImage; // Changed from SpriteRenderer to Image
    public Conversation conversation;
    private ADTQueue<DialogueItem> dialogueQueue;

    void Start()
    {
        dialogueQueue = new ADTQueue<DialogueItem>();
        foreach (var item in conversation.dialogueItems)
        {
            dialogueQueue.Enqueue(item);
        }
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (dialogueQueue.Peek() != null) // Check if the queue is not empty using Peek
        {
            DialogueItem item = dialogueQueue.Dequeue();
            nameText.text = item.speaker.speakerName;
            dialogueText.text = item.dialogue;

            // Assuming the prefab has an Image component directly attached to it
            Image speakerImage = item.speaker.portraitPrefab.GetComponent<Image>();
            if (speakerImage != null)
            {
                portraitImage.sprite = speakerImage.sprite;
            }
        }
    }
}
