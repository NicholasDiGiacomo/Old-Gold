using UnityEngine;

public class EndingManager : MonoBehaviour
{
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

    public bool IsEndingActive => endingActive;

    public void ReachExit(int collectedValue)
    {
        if (endingActive)
            return;

        if (collectedValue >= debtAmount)
            StartEnding(debtPaidScreens);
        else
            StartEnding(enslavedScreens);
    }

    public void PlayerDied()
    {
        if (endingActive)
            return;

        StartEnding(deathScreens);
    }

    private void StartEnding(GameObject[] screens)
    {
        endingActive = true;
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