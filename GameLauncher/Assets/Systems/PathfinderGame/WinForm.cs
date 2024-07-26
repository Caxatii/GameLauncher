using UnityEngine;

using TMPro;
using System;

public class WinForm : MonoBehaviour
{
    [SerializeField]
    private TMP_Text
        _playerTime, _bestTime;

    public void Show(TimeSpan time)
    {
        SetTime(time);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _bestTime.text = "Loading...";
    }

    public void SetTime(TimeSpan time)
    {
        _playerTime.text = time.Seconds.ToString() + 's';
    }
}
