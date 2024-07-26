using UnityEngine;

public class LoadData : MonoBehaviour
{
    private void OnEnable()
    {
        DataInitialization.Load();
    }
}
