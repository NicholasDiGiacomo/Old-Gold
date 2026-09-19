using UnityEngine;


//
// INVENTORY INTEGRATION NOTES
//
// This script currently stores the player's collected items:
// GoldBars, Rocks, Diamonds, and CopperNuggets.
//
// It also calculates WeightModifier and CollectedValue.
//
// TODO (Inventory):
// Read these existing properties to display item counts and totals.
// Avoid maintaining a separate set of item counts in the UI,
// as the two sets of values could become out of sync.
//

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
// TODO (Inventory):
// These methods are called when the player collects an item.
//
// After an item is added, the inventory UI should refresh to
// display the updated count, total weight, and total value.
//
// Possible approach:
// Add an OnInventoryChanged event to PlayerWeight and invoke it
// whenever an item is added or removed. The inventory UI can
// subscribe to that event instead of checking every frame.
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

// TODO (Inventory):
// These methods already handle removing items and updating totals.
//
// If the inventory allows the player to drop or discard items,
// call the corresponding Remove method.
//
// Each method returns false if the player does not have that item.
// Only update the UI or spawn a dropped item if removal succeeds.
//
// Remember to refresh the inventory display after a successful removal.
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