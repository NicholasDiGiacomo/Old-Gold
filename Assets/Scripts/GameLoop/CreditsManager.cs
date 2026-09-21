
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] creditPanels;
    [SerializeField] private string returnScene = "MainMenu";

    private int currentPanel;

    private void Start()
    {
        Time.timeScale = 1f;

        if (creditPanels.Length == 0)
            return;

        currentPanel = 0;

        for (int i = 0; i < creditPanels.Length; i++)
            creditPanels[i].SetActive(i == currentPanel);
    }

    public void NextPanel()
    {
        if (creditPanels.Length == 0)
        {
            ReturnToMenu();
            return;
        }

        creditPanels[currentPanel].SetActive(false);
        currentPanel++;

        if (currentPanel >= creditPanels.Length)
        {
            ReturnToMenu();
            return;
        }

        creditPanels[currentPanel].SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(returnScene);
    }
}