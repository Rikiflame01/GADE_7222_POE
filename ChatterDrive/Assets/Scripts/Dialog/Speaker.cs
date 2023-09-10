using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/Speaker")]
public class Speaker : ScriptableObject
{
    public string speakerName;
    public GameObject portraitPrefab;
}