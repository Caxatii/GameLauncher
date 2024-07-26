using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent (typeof(Image))]
public class InteractiveImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private Color _push—olor;
    private Color _baseColor;

    private Image _image;
    private bool _isInteractable;

    public event Action onClick;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        _baseColor = _image.color;
    }

    public void Init(Sprite sprite, bool isInteractable)
    {
        _image.sprite = sprite;
        _isInteractable = isInteractable;
    }

    private void UpdateImage(bool isMouseEnter)
    {
        if (!_isInteractable) return;

        var color = isMouseEnter ? _push—olor : _baseColor;

        _image.color = color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateImage(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UpdateImage(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isInteractable) return;
        onClick?.Invoke(); ;
    }
}
