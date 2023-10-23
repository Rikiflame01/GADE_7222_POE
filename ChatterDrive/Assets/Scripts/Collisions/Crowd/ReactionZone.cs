using UnityEngine;
using UnityEngine.Events;

public class ReactionZone : MonoBehaviour
{
    public UnityEvent OnCrash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crashable"))
        {
            OnCrash.Invoke();
        }
    }
}
