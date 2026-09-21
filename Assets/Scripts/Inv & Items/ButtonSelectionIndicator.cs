
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelectionIndicator : MonoBehaviour,
    ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject selectionIndicator;

    private void OnEnable()
    {
        if (selectionIndicator != null)
            selectionIndicator.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (selectionIndicator != null)
            selectionIndicator.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (selectionIndicator != null)
            selectionIndicator.SetActive(false);
    }

    private void OnDisable()
    {
        if (selectionIndicator != null)
            selectionIndicator.SetActive(false);
    }
}