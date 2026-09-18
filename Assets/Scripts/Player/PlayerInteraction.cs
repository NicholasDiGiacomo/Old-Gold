using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private EndingManager endingManager;

    public void OnInteract()
    {
        Debug.Log("INTERACT PRESSED");

        if (endingManager != null && endingManager.IsEndingActive)
        {
            Debug.Log("ADVANCING ENDING");
            endingManager.AdvanceEnding();
        }
    }
}