using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogComponent : ScriptableObject
{
    public abstract string GetDialogText();
    public abstract void Display();
}