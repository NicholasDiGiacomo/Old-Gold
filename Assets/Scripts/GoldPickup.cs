using UnityEngine;
// handles logic for gold pickup 
public class GoldPickup : MonoBehaviour
{
    [SerializeField] int WeightFoeGoldPickup = 1;
     bool wasColllected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasColllected)
        {
            wasColllected = true;
           
            gameObject.SetActive(false);
            Destroy(gameObject, 0.25f);
            
             
        }
    }

}
