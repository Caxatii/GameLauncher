using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class MinigamePreview : MonoBehaviour
{
    [SerializeField]
    private InteractiveImage _image;

    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Button _loadButton;

    [SerializeField]
    private Button _unloadButton;

    private bool _isLoaded;

    public void Init(Sprite image, string gameName, bool isLoaded)
    {
        _image.Init(image, isLoaded);
        _text.text = gameName;
        _isLoaded = isLoaded;
    }

    private void OnEnable()
    {
        _loadButton.onClick.AddListener(Load);
        _unloadButton.onClick.AddListener(Unload);

        if (_isLoaded)
        {
            _loadButton.interactable = false;
            _unloadButton.interactable = true;
        }
        else
        {
            _loadButton.interactable = true;
            _unloadButton.interactable = false;
        }
    }

    private void Unload()
    {
        throw new NotImplementedException();
    }

    private void Load()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        _loadButton?.onClick.RemoveListener(Load);
        _unloadButton?.onClick.RemoveListener(Unload);
    }
}
