using UnityEngine;

public class CopperPickup : MonoBehaviour, IItemPickup
{
    // each pickup class handles individual pickup logic with only pickup OnInteract which is currently Kkey as requested 
    [SerializeField] private AudioClip pickupSound;

    private PlayerInteraction nearbyPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteraction interaction =
            other.GetComponent<PlayerInteraction>();

        if (interaction == null)
            return;

        // Register this item without collecting it.
        nearbyPlayer = interaction;
        interaction.SetNearbyPickup(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerInteraction interaction =
            other.GetComponent<PlayerInteraction>();

        if (interaction == null || interaction != nearbyPlayer)
            return;

        interaction.ClearNearbyPickup(this);
        nearbyPlayer = null;
    }

// TODO (Inventory):
// PlayerWeight.AddCopperNugget() updates the player's stored item count,
// total weight, and total value.
//
// The inventory UI should reflect this change after collection.
// Do not add a second inventory count here.
//
// Collection is initiated by PlayerInteraction when E is pressed.
// Keep the pickup's trigger responsible only for detecting proximity.
    public void Collect(PlayerWeight playerWeight)
    {
        // Add the item only when the player presses Interact.
        playerWeight.AddCopperNugget();

        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(
                pickupSound,
                transform.position
            );

        if (nearbyPlayer != null)
            nearbyPlayer.ClearNearbyPickup(this);

        Destroy(gameObject);
    }
}