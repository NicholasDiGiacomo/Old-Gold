
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuSelection : MonoBehaviour
{
    [SerializeField] private Button resumeButton;

    private IEnumerator Start()
    {
        // Wait one frame for the additively loaded menu to initialize.
        yield return null;

        EventSystem eventSystem = EventSystem.current;

        if (eventSystem != null && resumeButton != null)
        {
            eventSystem.SetSelectedGameObject(null);
            eventSystem.SetSelectedGameObject(resumeButton.gameObject);
        }
    }
}