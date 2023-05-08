using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject blocker;
    private Outline outline;
    private TMP_Text text;
    private Image image;


    private void OnEnable()
    {
        outline = GetComponent<Outline>();
        text = GetComponentInChildren<TMP_Text>();
        image = GetComponent<Button>().image;

        ChangeColor(false);
        image.fillAmount = 0;
        outline.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeColor(true);
        image.DOFillAmount(1, 1).From(0).SetEase(Ease.OutExpo);
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.Kill("Button");
        ChangeColor(false);
        image.DOFillAmount(0, 0).From(1).SetEase(Ease.OutExpo).SetId("Button");
        outline.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        blocker.SetActive(true);
    }

    private void ChangeColor(bool value)
    {
        string hex1 = "#00C7EE";
        string hex2 = "#F3454D";

        ColorUtility.TryParseHtmlString(hex1, out Color blue);
        ColorUtility.TryParseHtmlString(hex2, out Color red);

        if (value)
        {
            text.color = blue;
        }
        else
        {
            text.color = red;
        }
    }

}
