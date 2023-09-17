using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuCollapserUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI _textHighlighting;

    private GameObject _abilityPanel;
    private GameObject _downAbilityPanel;
    
    private float _downPanelHeigh;

    private bool _isDownPanelActive;

    private void Awake()
    {
        _textHighlighting = GetComponent<TextMeshProUGUI>();

        _abilityPanel = GameObject.FindGameObjectWithTag("AbilityPanel");
        _downAbilityPanel = _abilityPanel.transform.GetChild(1).gameObject;

        _downPanelHeigh = _downAbilityPanel.GetComponent<RectTransform>().rect.height;
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
