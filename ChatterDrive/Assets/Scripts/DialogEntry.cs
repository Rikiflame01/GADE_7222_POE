using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogSystem/DialogEntry")]
public class DialogEntry : DialogComponent
{
    public string ID;
    public string SpeakerName;
    public string DialogID;
    public string Text;

    public override string GetDialogText()
    {
        return $"{SpeakerName}: {Text}";
    }

    public override void Display()
    {
        // Logic for displaying this entry
    }
}

