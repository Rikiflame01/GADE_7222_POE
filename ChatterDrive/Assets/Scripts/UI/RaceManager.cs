using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI lapText;
    public List<Transform> allRacers; 

    private Waypoints waypoints;
    private int currentWaypointIndex = 0;
    private int lapCount = 0;
    private Dictionary<Transform, int> racerWaypointCount = new Dictionary<Transform, int>();

    void Start()
    {
        waypoints = Waypoints.Instance;
        lapCount = 1; // Set initial lap count to 1

        // Initialize the racerWaypointCount dictionary for each racer
        foreach (Transform racer in allRacers)
        {
            racerWaypointCount[racer] = 0;
        }
    }


    void Update()
    {
        CheckWaypointPass();
        UpdateUI();
    }

    void CheckWaypointPass()
    {
        foreach (Transform racer in allRacers)
        {
            int racerCurrentWaypoint = racerWaypointCount[racer];
            float distanceToWaypoint = Vector3.Distance(racer.position, waypoints.GetNextWaypoint(racerCurrentWaypoint).position);
            if (distanceToWaypoint < 5f) // Assuming 5 units as the threshold
            {
                racerCurrentWaypoint++;
                if (racerCurrentWaypoint >= waypoints.GetNumWaypoints())
                {
                    racerCurrentWaypoint = 0;
                    // Check if the racer has passed the last waypoint
                    if (racer == playerTransform && lapCount < 3) // Ensure lapCount doesn't exceed 3
                    {
                        lapCount++;
                    }
                }
                racerWaypointCount[racer] = racerCurrentWaypoint; // Update the dictionary
            }
        }
    }




    void UpdateUI()
    {
        positionText.text = GetPositionSuffix(CalculatePlayerPosition());
        lapText.text = "Lap " + lapCount + "/3";
    }

    int CalculatePlayerPosition()
    {
        int position = 1; // Default to 1st place
        foreach (Transform racer in allRacers)
        {
            if (racer == playerTransform) continue; // Skip the player

            if (racerWaypointCount[racer] > racerWaypointCount[playerTransform])
            {
                position++;
            }
            else if (racerWaypointCount[racer] == racerWaypointCount[playerTransform])
            {
                float racerDistanceToNext = Vector3.Distance(racer.position, waypoints.GetNextWaypoint(racerWaypointCount[racer]).position);
                float playerDistanceToNext = Vector3.Distance(playerTransform.position, waypoints.GetNextWaypoint(racerWaypointCount[playerTransform]).position);
                if (racerDistanceToNext < playerDistanceToNext)
                {
                    position++;
                }
            }
        }
        return position;
    }

    string GetPositionSuffix(int position)
    {
        switch (position)
        {
            case 1: return position + "st";
            case 2: return position + "nd";
            case 3: return position + "rd";
            default: return position + "th";
        }
    }
}
