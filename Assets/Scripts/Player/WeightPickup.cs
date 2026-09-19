// using UnityEngine;

// public class WeightPickup : MonoBehaviour
// {
//     [SerializeField] private PickupType pickupType;
//     [SerializeField] private AudioClip pickupSound;

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         PlayerWeight playerWeight = other.GetComponent<PlayerWeight>();

//         if (playerWeight == null)
//             return;

//         switch (pickupType)
//         {
//             case PickupType.GoldBar:
//                 playerWeight.AddGoldBar();
//                 break;

//             case PickupType.Rock:
//                 playerWeight.AddRock();
//                 break;

//             case PickupType.Diamond:
//                 playerWeight.AddDiamond();
//                 break;
//         }

//         if (pickupSound != null)
//             AudioSource.PlayClipAtPoint(pickupSound, transform.position);

//         Destroy(gameObject);
//     }
// }