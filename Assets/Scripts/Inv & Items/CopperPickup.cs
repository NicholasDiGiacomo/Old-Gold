using UnityEngine;

public class CopperPickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

        if (playerWeight == null)
            return;

        playerWeight.AddCopperNugget();

        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        Destroy(gameObject);
    }
}