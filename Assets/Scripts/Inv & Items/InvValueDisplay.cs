using TMPro;
using UnityEngine;

//script is responsible for displying how much of each item does the player carry
public class InvValueDisplay : MonoBehaviour
{
    //decider is changed from the inspector to decide which text displays which value depending on deciders value
    [SerializeField] int decider;
    [SerializeField] TextMeshProUGUI tmo;
    PlayerWeight plw;

    void Start()
    {
        //searches in all active scenes for an object that has player weight script attached
        plw = FindAnyObjectByType(typeof(PlayerWeight)) as PlayerWeight;
    }

    // Update is called once per frame
    void Update()
    {
        //1 for gold bars
        //0 for diamonds
        //2 for copper nuggets
        //3 for rocks

        if (decider == 0) { tmo.text = plw.Diamonds.ToString(); }
        else if (decider == 1) { tmo.text = plw.GoldBars.ToString(); }
        else if (decider == 2) { tmo.text = plw.CopperNuggets.ToString(); }
        else if (decider == 3) { tmo.text = plw.Rocks.ToString(); }
    }
}
