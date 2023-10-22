using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text positionText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text colourText;

    public string RacerName { get; private set; }

    public void SetUpRacerUI(string position, string name, string teamColour)
    {
        RacerName = name;
        positionText.text = position;
        nameText.text = name;
        colourText.text = teamColour;
    }

    public void ChangeRacerPos(string position)
    {
        positionText.text = position;
    }
}
