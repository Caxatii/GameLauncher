using System;
using UnityEngine;

public class PathfinderGame : MonoBehaviour
{
    [SerializeField]
    private WinForm _winForm;

    [SerializeField, Tooltip("The starting position will be obtained from the prefab on the scene")]
    private Player _player;

    private Transform _startPoint;
    private DateTime _time;

    private void OnEnable()
    {
        var finish = FindFirstObjectByType<Finish>();
        finish.OnFinish += EndGame;
        
        _startPoint = _player.transform;

        StartGame();
    }

    private void EndGame()
    {
        _winForm.Show(DateTime.Now - _time);
    }

    public void StartGame()
    {
        _time = DateTime.Now;

        _winForm.Hide();

        _player.gameObject.SetActive(true);
        _player.transform.position = _startPoint.position;
        _player.transform.rotation = _startPoint.rotation;
    }
}
