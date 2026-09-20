using System.Collections;
using System.Diagnostics;
using UnityEngine;

//this script is responsible for decding which item to throw
public class ThrowDecider : MonoBehaviour
{
    PlayerWeight plw;
    void Start()
    {
        plw = FindAnyObjectByType(typeof(PlayerWeight)) as PlayerWeight;
    }

    public void ThrowGold()
    {
        plw.RemoveGoldBar();
    }
    public void ThrowDiamond()
    {
        plw.RemoveDiamond();
    }
    public void ThrowCopper()
    {
        plw.RemoveCopperNugget();
    }
    public void ThrowRock()
    {
        plw.RemoveRock();
    }
}
