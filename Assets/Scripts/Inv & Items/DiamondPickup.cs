using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

        if (playerWeight == null)
            return;

        playerWeight.AddDiamond();

        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        Destroy(gameObject);
    }
}