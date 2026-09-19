using UnityEngine;

public class PlayerWeight : MonoBehaviour
{
    [Header("Gold Bar")]
    [SerializeField] private int goldWeight = 3;
    [SerializeField] private int goldValue = 5;

    [Header("Rock")]
    [SerializeField] private int rockWeight = 5;
    [SerializeField] private int rockValue = 1;

    [Header("Diamond")]
    [SerializeField] private int diamondWeight = 5;
    [SerializeField] private int diamondValue = 10;

    [Header("Copper")]
    [SerializeField] private int copperWeight = 2;
    [SerializeField] private int copperValue = 3;

    [SerializeField] Animator animator;

    // Item counts
    public int GoldBars { get; private set; }
    public int Rocks { get; private set; }
    public int Diamonds { get; private set; }
    public int CopperNuggets { get; private set; }

    // Totals
    public int WeightModifier { get; private set; }
    public int CollectedValue { get; private set; }

    // -------------------------
    // ADD ITEMS
    // -------------------------

    public void AddGoldBar()
    {
        GoldBars++;
        WeightModifier += goldWeight;
        CollectedValue += goldValue;
        animator.SetTrigger("PickedUp");
    }

    public void AddRock()
    {
        Rocks++;
        WeightModifier += rockWeight;
        CollectedValue += rockValue;
        animator.SetTrigger("PickedUp");
    }

    public void AddDiamond()
    {
        Diamonds++;
        WeightModifier += diamondWeight;
        CollectedValue += diamondValue;
        animator.SetTrigger("PickedUp");
    }

    public void AddCopperNugget()
    {
        CopperNuggets++;
        WeightModifier += copperWeight;
        CollectedValue += copperValue;
        animator.SetTrigger("PickedUp");
    }

    // -------------------------
    // REMOVE ITEMS
    // -------------------------

    public bool RemoveGoldBar()
    {
        if (GoldBars <= 0)
            return false;

        GoldBars--;
        WeightModifier -= goldWeight;
        CollectedValue -= goldValue;
        animator.SetTrigger("PickedUp");

        return true;
    }

    public bool RemoveRock()
    {
        if (Rocks <= 0)
            return false;

        Rocks--;
        WeightModifier -= rockWeight;
        CollectedValue -= rockValue;
        animator.SetTrigger("PickedUp");

        return true;
    }

    public bool RemoveDiamond()
    {
        if (Diamonds <= 0)
            return false;

        Diamonds--;
        WeightModifier -= diamondWeight;
        CollectedValue -= diamondValue;
        animator.SetTrigger("PickedUp");

        return true;
    }

    public bool RemoveCopperNugget()
    {
        if (CopperNuggets <= 0)
            return false;

        CopperNuggets--;
        WeightModifier -= copperWeight;
        CollectedValue -= copperValue;
        animator.SetTrigger("PickedUp");

        return true;
    }
}