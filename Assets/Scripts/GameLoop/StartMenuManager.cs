using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
     [SerializeField] private GameObject pressAnyButtonPanel;
     [SerializeField] private GameObject[] storyPanels;
     [SerializeField] private string gameSceneName = "Game";
     private int currentPanel = -1;
     private bool storyStarted;
    void Update()
    {
        if(!storyStarted)
        {
           if(AnyButtonPressed())
            {
                StartStory();
            } 
            return;
        }



        //E
        bool keyboardInteract = Keyboard.current != null
        && Keyboard.current.eKey.wasPressedThisFrame;

        // gamepad west
        bool gamepandInteract = Gamepad.current != null 
        && Gamepad.current.buttonWest.wasPressedThisFrame; 

        if(keyboardInteract || gamepandInteract)
        {
            AdvanceStory();
        }

            
    }




    private bool AnyButtonPressed()
{
    // Any keyboard key
    if (Keyboard.current != null &&
        Keyboard.current.anyKey.wasPressedThisFrame)
    {
        return true;
    }

    // Common gamepad buttons
    if (Gamepad.current != null)
    {
        Gamepad gamepad = Gamepad.current;

        if (gamepad.buttonSouth.wasPressedThisFrame ||
            gamepad.buttonNorth.wasPressedThisFrame ||
            gamepad.buttonEast.wasPressedThisFrame ||
            gamepad.buttonWest.wasPressedThisFrame ||
            gamepad.startButton.wasPressedThisFrame ||
            gamepad.selectButton.wasPressedThisFrame ||
            gamepad.leftShoulder.wasPressedThisFrame ||
            gamepad.rightShoulder.wasPressedThisFrame ||
            gamepad.leftStickButton.wasPressedThisFrame ||
            gamepad.rightStickButton.wasPressedThisFrame ||
            gamepad.dpad.up.wasPressedThisFrame ||
            gamepad.dpad.down.wasPressedThisFrame ||
            gamepad.dpad.left.wasPressedThisFrame ||
            gamepad.dpad.right.wasPressedThisFrame)
        {
            return true;
        }
    }

    return false;
}

    private void StartStory()
    {
        storyStarted = true; 

        pressAnyButtonPanel.SetActive(false);

        currentPanel = 0;

        if(storyPanels.Length > 0)
        {
            storyPanels[currentPanel].SetActive(true);

        }
        else
        {
            StartGame();
        }
    }

    private void AdvanceStory()
    {
        storyPanels[currentPanel].SetActive(false);

        currentPanel++;

        if(currentPanel >= storyPanels.Length)
        {
            StartGame();
            return;
        }
        storyPanels[currentPanel].SetActive(true);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
