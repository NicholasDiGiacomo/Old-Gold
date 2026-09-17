using UnityEngine;

public class WeightPickup : MonoBehaviour
{
    [SerializeField] private int weightAmount = 1;
    [SerializeField] private int valueAmount = 1;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

        if (playerWeight == null)
            return;

        playerWeight.AddWeight(weightAmount);
        playerWeight.AddValue(valueAmount);

        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(
                pickupSound,
                transform.position
            );
        }

        Destroy(gameObject);
    }
}