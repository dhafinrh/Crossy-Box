using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private TMP_Text text;
    private Image image;

    private void OnEnable()
    {
        text = GetComponentInChildren<TMP_Text>();
        image = GetComponent<Image>();

        ChangeColor(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeColor(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeColor(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeColor(true);
    }
    private void ChangeColor(bool value)
    {
        string hex1 = "#000000";
        string hex2 = "#00C7EE";

        ColorUtility.TryParseHtmlString(hex1, out Color black);
        ColorUtility.TryParseHtmlString(hex2, out Color blue);

        if (value)
        {
            text.color = black;
            image.color = blue;
        }
        else
        {
            text.color = blue;
            image.color = black;
        }
    }

}
