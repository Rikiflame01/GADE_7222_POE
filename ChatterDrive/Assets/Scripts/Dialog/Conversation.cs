using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogSystem/Conversation")]
public class Conversation : ScriptableObject
{
    public List<DialogueItem> dialogueItems;
}