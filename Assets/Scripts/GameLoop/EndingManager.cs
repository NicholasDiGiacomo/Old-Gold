using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private int debtAmount = 20;
    [Header("Menu Navigation")]
    [SerializeField] private GameObject replayButton;

    [Header("Ending Screens")]
    [SerializeField] private GameObject[] debtPaidScreens;
    [SerializeField] private GameObject[] enslavedScreens;
    [SerializeField] private GameObject[] deathScreens;

    [Header("Menu")]
    [SerializeField] private GameObject endingMenu;
    [SerializeField] private GameMusicManager musicManager;

    private GameObject[] currentEnding;
    private int currentScreen;
    private bool endingActive;

    public bool IsEndingActive => endingActive;

    public void ReachExit(int collectedValue)
        {
            if (endingActive)
             return;

            if (collectedValue >= debtAmount)
            {
                if (musicManager != null)
                    musicManager.PlaySuccessMusic();

                StartEnding(debtPaidScreens);
            }
            else
            {
                if (musicManager != null)
                    musicManager.PlayFailureMusic();

                StartEnding(enslavedScreens);
            }
        }

public void PlayerDied()
        {
            if (endingActive)
                return;

            if (musicManager != null)
                musicManager.PlayFailureMusic();

            StartEnding(deathScreens);
        }

    private void StartEnding(GameObject[] screens)
    {
       if (endingActive)
        return;

    endingActive = true;
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