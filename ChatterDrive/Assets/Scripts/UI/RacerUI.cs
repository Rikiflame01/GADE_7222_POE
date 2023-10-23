using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RacerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text positionText;
    [SerializeField] private TMP_Text nameText;

    public string RacerName { get; private set; }
    //Setup racer UI 
    public void SetUpRacerUI(string position, string name)
    {
        RacerName = name;
        positionText.text = position;
        nameText.text = name;   
    }
}
