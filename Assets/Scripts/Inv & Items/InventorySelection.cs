
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySelection : MonoBehaviour
{
    [SerializeField] private Button firstButton;

    private IEnumerator Start()
    {
        // Wait for the additively loaded Inventory scene
        // and its UI controls to finish initializing.
        yield return null;

        if (EventSystem.current == null || firstButton == null)
            yield break;

        // Clear the selection left over from PauseMenu.
        EventSystem.current.SetSelectedGameObject(null);

        // Give keyboard/gamepad navigation a starting point.
        EventSystem.current.SetSelectedGameObject(
            firstButton.gameObject
        );
    }
}