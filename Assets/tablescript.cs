using UnityEngine;
public class TableScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InteractableObject>(out var interactable))
        {
            interactable.Target();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractableObject>(out var interactable))
        {
            interactable.UnTarget();
        }
    }
}
