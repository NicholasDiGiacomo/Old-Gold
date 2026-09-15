using UnityEngine;
// Handles logic for gold pickup
public class GoldPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

        if (playerWeight != null)
        {
            playerWeight.AddWeight(1);
            Destroy(gameObject);
        }
    }

}
