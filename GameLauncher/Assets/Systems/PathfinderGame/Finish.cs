using System;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Finish : MonoBehaviour
{
    private Collider _collider;

    public event Action OnFinish;

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.gameObject.SetActive(false);
            OnFinish?.Invoke();
        }
    }
}
