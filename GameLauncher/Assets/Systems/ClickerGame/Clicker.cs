using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Clicker : MonoBehaviour
{
    [SerializeField]
    private string _scoreText;

    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Button _button;

    private int _score;

    public void Init(int score = 0)
    {
        _score = score;
        UpdateUIText();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        UpdateUIText();
    }

    private void OnClick()
    {
        _score++;
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        _text.text = _scoreText + _score.ToString();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
