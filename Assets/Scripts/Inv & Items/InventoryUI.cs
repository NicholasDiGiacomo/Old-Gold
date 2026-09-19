using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
       [SerializeField] PlayerWeight playerWeight;

       [Header("counts")]
       [SerializeField] private TextMeshProUGUI goldCount;
       [SerializeField] private TextMeshProUGUI rockCount;
       [SerializeField] private TextMeshProUGUI diamondCount;
       [SerializeField] private TextMeshProUGUI copperCount;

       [Header("totals")]
       [SerializeField] private TextMeshProUGUI weightText;
       [SerializeField] private TextMeshProUGUI valueText;

       [Header("Highlights")]
       [SerializeField] private GameObject goldHighlight;
       [SerializeField] private GameObject rockHighlight;
       [SerializeField] private GameObject diamondHighlight;
       [SerializeField] private GameObject copperHighlight;

       private int selectedItem;

    void Start()
    {
        selectedItem = 0;
        RefreshUI();
    }

    void Update()
    {
         RefreshUI();
    }

    public void SelectLeft()
    {
        selectedItem--;
        if(selectedItem < 0) selectedItem = 3;
        
        RefreshHighlights();


    }

    public void SelectRight()
    {
        selectedItem++;
        if(selectedItem > 3) selectedItem = 0;

        RefreshHighlights();
    }

    public void RemoveSelected()
    {
        switch(selectedItem)
        {
            case 0:
                playerWeight.RemoveGoldBar();
                break;
            case 1:
                playerWeight.RemoveRock();
                break;
            case 2:
                playerWeight.RemoveDiamond();
                break;
            case 3:
                playerWeight.RemoveCopperNugget();
                break;
        }
        RefreshUI();
    }

    private void RefreshUI()
    {
        goldCount.text = playerWeight.GoldBars.ToString();
        rockCount.text = playerWeight.Rocks.ToString();
        diamondCount.text = playerWeight.Diamonds.ToString();
        copperCount.text = playerWeight.CopperNuggets.ToString();

        weightText.text = "weight: " + playerWeight.WeightModifier;
        valueText.text = "Value: " + playerWeight.CollectedValue;

        RefreshHighlights();
    }

    private void RefreshHighlights()
    {
        goldHighlight.SetActive(selectedItem == 0);
        rockHighlight.SetActive(selectedItem == 1);
        diamondHighlight.SetActive(selectedItem == 2);
        copperHighlight.SetActive(selectedItem == 3);
    }
}
