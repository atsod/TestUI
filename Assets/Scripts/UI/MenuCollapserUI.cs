using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuCollapserUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _abilityPanel;
    [SerializeField] private GameObject _downAbilityPanel;

    private float _downPanelHeigh;
    private bool _isDownPanelActive;

    private TextMeshProUGUI _textHighlighting;

    private void Awake()
    {
        _downPanelHeigh = _downAbilityPanel.GetComponent<RectTransform>().rect.height;

        _textHighlighting = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _textHighlighting.fontStyle = FontStyles.Underline;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _textHighlighting.fontStyle = FontStyles.Normal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            RectTransform panelTransform = _abilityPanel.GetComponent<RectTransform>();
            Vector2 panelPosition = panelTransform.anchoredPosition;

            panelTransform.anchoredPosition = new Vector2(
                    panelPosition.x,
                    panelPosition.y + _downPanelHeigh * (_isDownPanelActive ? -1 : 1));

            _isDownPanelActive = !_isDownPanelActive;
        }
    }
}
