using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class Player : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);
    public const string Vertical = nameof(Vertical);
    public const string isRunning = nameof(isRunning);

    [SerializeField]
    private float 
        _rotationSpeed,
        _runningSpeed;

    private CharacterController _controller;
    private Animator _animator;
    private Camera _camera;

    private bool _isRunning;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        SetCamera();
    }

    private void SetCamera()
    {
        _camera = Camera.main;
        if(_camera.TryGetComponent<CameraAuto>(out CameraAuto auto))
        {
            auto.SetTarget(transform);
        }
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis(Horizontal);
        var y = Input.GetAxis(Vertical);

        Move(y);
        Rotate(x);
    }

    private void Move(float input)
    {
        if(input == 0)
        {
            DeactivateAnimation();
            return;
        }

        ActivateAnimation();

        var newVector = _controller.transform.forward * input * _runningSpeed * Time.deltaTime;

        newVector.y = -0.05f;

        _controller.Move(newVector);
    }

    private void Rotate(float input)
    {
        if (input == 0) return;

        var newVector = new Vector3(0, input * _rotationSpeed, 0);

        _controller.transform.Rotate(newVector);
    }

    private void ActivateAnimation()
    {
        if (_isRunning) return;

        _isRunning = true;
        _animator.SetBool(isRunning, _isRunning);
    }

    private void DeactivateAnimation()
    {
        if (!_isRunning) return;

        _isRunning = false;
        _animator.SetBool(isRunning, _isRunning);
    }
}
