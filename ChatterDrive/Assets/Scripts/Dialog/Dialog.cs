using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

[CreateAssetMenu(menuName = "DialogSystem/Dialog")]
public class Dialog : DialogComponent
{
    public List<DialogComponent> Components;

    public override string GetDialogText()
    {
        StringBuilder dialogText = new StringBuilder();

        foreach (var component in Components)
        {
            dialogText.AppendLine(component.GetDialogText());
        }

        return dialogText.ToString();
    }

    public override void Display()
    {
        foreach (var component in Components)
        {
            component.Display();
            // Add a delay or user input requirement here if needed
        }
    }
}



