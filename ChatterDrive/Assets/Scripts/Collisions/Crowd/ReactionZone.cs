using UnityEngine;
using UnityEngine.Events;

public class ReactionZone : MonoBehaviour
{
    public UnityEvent OnCrash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crashable"))
        {
            Debug.Log("Crashed with: " + other.gameObject.name);
            OnCrash.Invoke();
        }
    }
}
