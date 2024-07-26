using Cinemachine;
using UnityEngine;

public class CameraAuto : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook _cinemachine;

    public void SetTarget(Transform point)
    {
        _cinemachine.Follow = point;
        _cinemachine.LookAt = point;
    }
}
