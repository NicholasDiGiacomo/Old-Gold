
using UnityEngine;

public class PlayerWeight : MonoBehaviour
{
    public int WeightModifier { get; private set; }
     public int CollectedValue { get; private set; }

    public void AddWeight(int amount)
    {
        WeightModifier += amount;
    }

    public void AddValue(int amount)
    {
         CollectedValue += amount;

        Debug.Log("Collected Value: " + CollectedValue);
    }
}
