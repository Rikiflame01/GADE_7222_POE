using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public SpriteRenderer portraitImage;
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
            portraitImage.sprite = item.speaker.portrait;
        }
    }
}
