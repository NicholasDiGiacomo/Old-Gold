using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class EndingManager : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private GameObject replayButton;
    [SerializeField] private int debtAmount = 20;

    [Header("Ending Screens")]
    [SerializeField] private GameObject[] debtPaidScreens;
    [SerializeField] private GameObject[] enslavedScreens;
    [SerializeField] private GameObject[] deathScreens;

    [Header("Menu")]
    [SerializeField] private GameObject endingMenu;

    private GameObject[] currentEnding;
    private int currentScreen;
    private bool endingActive;

    private bool endingTriggered = false;

    public bool IsEndingActive => endingActive;
    public bool HasEndingTriggered => endingTriggered;

    

    public void ReachExit(int collectedValue)
    {
        if (endingTriggered)
            return;

        if (collectedValue >= debtAmount)
            StartEnding(debtPaidScreens);
        else
            StartEnding(enslavedScreens);
    }

    public void PlayerDied()
    {
        if (endingTriggered)
            return;

        StartEnding(deathScreens);
    }

    private void StartEnding(GameObject[] screens)
    {
        if (endingTriggered)
            return;

        endingTriggered = true;
        endingActive = true;

        // Stop gameplay.
        Time.timeScale = 0f;

        currentEnding = screens;
        currentScreen = 0;

        DisableAllScreens();

        currentEnding[currentScreen].SetActive(true);
    }

    public void AdvanceEnding()
    {
        if (!endingActive)
            return;

        currentEnding[currentScreen].SetActive(false);

        currentScreen++;

        if (currentScreen >= currentEnding.Length)
        {
            FinishEnding();
            return;
        }

        currentEnding[currentScreen].SetActive(true);
    }

    private void FinishEnding()
{
    endingActive = false;

    endingMenu.SetActive(true);

    StartCoroutine(SelectReplayNextFrame());
}

private IEnumerator SelectReplayNextFrame()
{
    // Wait until the Interact press that closed the ending
    // has finished being processed.
    yield return null;

    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(replayButton);
}

    private void DisableAllScreens()
    {
        foreach (GameObject screen in debtPaidScreens)
            screen.SetActive(false);

        foreach (GameObject screen in enslavedScreens)
            screen.SetActive(false);

        foreach (GameObject screen in deathScreens)
            screen.SetActive(false);

        endingMenu.SetActive(false);
    }
}