using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject _highlightedItem;

    private void Awake()
    {
        _highlightedItem = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        _highlightedItem.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _highlightedItem.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _highlightedItem.SetActive(false);
    }
}
