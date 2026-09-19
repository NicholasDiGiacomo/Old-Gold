using UnityEngine;

public class RockPickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

        if (playerWeight == null)
            return;

        playerWeight.AddRock();

        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        Destroy(gameObject);
    }
}