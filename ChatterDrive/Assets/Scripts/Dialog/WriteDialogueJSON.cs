using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WriteDialogueJSON : MonoBehaviour
{
    public List<DialogueItem> dialogueItems = new List<DialogueItem>();
    public const string DATA_PATH_DIALOGUE = "/DialogueText/dialogue.txt";

    public void WriteDialogueToJson(/*string name, int img, string dialogue*/)
    {
        DialogueItem item = new DialogueItem();
        item.name = "Mike";
        item.portraitImg = 1;
        item.dialogue = "Race like the wind";
        dialogueItems.Add(item);

        string output = JsonUtility.ToJson(item, true);

        try
        {

            File.AppendAllText(Application.dataPath + DATA_PATH_DIALOGUE, output);
        }
        catch(DirectoryNotFoundException e)
        {
            Debug.Log(e.ToString());
            File.WriteAllText(Application.dataPath + DATA_PATH_DIALOGUE, output);
        }
    }
}

[System.Serializable]
public class DialogueItem
{
    public string name;
    public int portraitImg;
    public string dialogue;
}
