
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private EndingManager endingManager;
    [SerializeField] private PlayerWeight playerWeight;

    private IItemPickup nearbyPickup;

    public void SetNearbyPickup(IItemPickup pickup)
    {
        nearbyPickup = pickup;
    }

    public void ClearNearbyPickup(IItemPickup pickup)
    {
        if (nearbyPickup == pickup)
            nearbyPickup = null;
    }

    public void OnInteract()
    {
        // Ending panels take priority over collecting items.
        if (endingManager != null && endingManager.IsEndingActive)
        {
            endingManager.AdvanceEnding();
            return;
        }

        // Prevent collecting items after any ending has triggered.
        if (endingManager != null && endingManager.IsEndingActive)
            return;

        // Collect the nearby item.
        if (nearbyPickup != null && playerWeight != null)
        {
            nearbyPickup.Collect(playerWeight);
            nearbyPickup = null;
        }
    }
}