using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ManagerTest : MonoBehaviour
{
    public TextMeshProUGUI uiText;  // Reference to the UI Text component
    public List<DialogComponent> Dialogs;  // List of DialogComponent objects
    public DialogComponent CurrentDialogComponent;
    private int currentEntryIndex = 0;  // To keep track of the dialog progress

    public void SetCurrentDialog(int index)
    {
        if (index >= 0 && index < Dialogs.Count)
        {
            CurrentDialogComponent = Dialogs[index];
            currentEntryIndex = 0;  // Reset the dialog index
        }
    }

    public void DisplayDialog()
    {
        string dialogText = CurrentDialogComponent.GetDialogText();
        uiText.text = dialogText;
        CurrentDialogComponent.Display();
    }

    public void AdvanceDialog()
    {
        if (CurrentDialogComponent is Dialog)
        {
            Dialog dialog = (Dialog)CurrentDialogComponent;
            if (currentEntryIndex < dialog.Components.Count)
            {
                uiText.text = dialog.Components[currentEntryIndex].GetDialogText();
                currentEntryIndex++;
            }
        }
    }
}





