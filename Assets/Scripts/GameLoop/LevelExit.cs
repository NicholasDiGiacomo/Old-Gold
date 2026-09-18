using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private EndingManager endingManager;

    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(hasTriggered) return;

        PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

        if(playerWeight == null) return;

        hasTriggered = true;

        endingManager.ReachExit(playerWeight.CollectedValue);
    }
}
