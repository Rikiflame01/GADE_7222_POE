using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUISetup : MonoBehaviour
{
    [Header("Dialogue Properties: ")]
    public Image portraitImage;
    public TextMeshProUGUI personNameTxt;
    public TextMeshProUGUI personDialogueTxt;

    public void SetPortraitImage(Image portraitImage)
    {
        this.portraitImage = portraitImage;
    }

    public void SetPersonNameText(TextMeshProUGUI personName)
    {
        personNameTxt = personName;
    }

    public void SetPersonDialogueText(TextMeshProUGUI dialgoue)
    {
        personDialogueTxt = dialgoue;
    }
}
