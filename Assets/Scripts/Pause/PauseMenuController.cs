using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    private void Start()
    {
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    public void Resume()
{
    Time.timeScale = 1f;

    SceneManager.UnloadSceneAsync("PauseMenu");
}
}