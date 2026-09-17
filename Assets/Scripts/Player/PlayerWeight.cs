using UnityEngine;

public class PlayerWeight : MonoBehaviour
{
    public int WeightModifier { get; private set; }

    public void AddWeight(int amount)
    {
        WeightModifier += amount;
    }
}
