using UnityEngine;
using UnityEngine.InputSystem;

public class EnableUIInput : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;

    private void OnEnable()
    {
        inputActions.FindActionMap("UI").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("UI").Disable();
    }
}