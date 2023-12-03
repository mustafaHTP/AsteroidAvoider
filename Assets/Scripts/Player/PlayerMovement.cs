using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Configs")]
    [Space(2)]
    [SerializeField] private float _forceMagnitude;
    [SerializeField] private float _rotationVelocity;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _borderOffset;

    private Camera _camera;
    private Rigidbody _playerRB;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchInput = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 touchInputInWorldSpace = _camera.ScreenToWorldPoint(touchInput);
            _moveDirection = ((Vector3)touchInputInWorldSpace - transform.position).normalized;
        }
        else
        {
            _moveDirection = Vector3.zero;
        }
    }

    private void Move()
    {
        Vector2 deltaMove = _moveDirection * _forceMagnitude * Time.fixedDeltaTime;
        _playerRB.AddForce(deltaMove);

        Vector3 clampedVelocity = Vector3.ClampMagnitude(
            _playerRB.velocity,
            _maxVelocity);

        _playerRB.velocity = clampedVelocity;
    }

    private void RotateToFaceVelocity()
    {
        if (_playerRB.velocity == Vector3.zero) return;

        float deltaRotation = _rotationVelocity * Time.fixedDeltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(_playerRB.velocity, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, deltaRotation);
    }

    private void KeepPlayerOnScreen()
    {
        Border cameraBorder = _camera.GetBorder();
        Vector2 nextPosition = _playerRB.position;

        if (_playerRB.position.x < cameraBorder.Left - _borderOffset || _playerRB.position.x > cameraBorder.Right + _borderOffset)
        {
            nextPosition.x = -1f * nextPosition.x;
        }

        if (_playerRB.position.y < cameraBorder.Bottom - _borderOffset || _playerRB.position.y > cameraBorder.Top + _borderOffset)
        {
            nextPosition.y = -1f * nextPosition.y;
        }

        _playerRB.position = nextPosition;
    }
}
