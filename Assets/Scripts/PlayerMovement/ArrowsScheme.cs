using System;
using UnityEngine;

public class ArrowsScheme : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 10f)]
    private float _speed;

    private Animator _animator;
    private Rigidbody2D _rb;

    private bool _isEnabled = false;
    private ushort _methodID = 2;

    [SerializeField] private KeyCode _downKey;
    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _rightKey;
    [SerializeField] private KeyCode _leftKey;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        MovementEvents.ChangeMovementInputMethodRequested.AddListener(OnChangeMovementInputMethodRequested);
        MovementEvents.ChangeMovementSpeedRequested.AddListener(OnChangeMovementSpeed);
    }

    private void OnChangeMovementSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    private void OnChangeMovementInputMethodRequested(ushort methodID)
    {
        if (methodID != _methodID)
        {
            if (_isEnabled)
            {
                _isEnabled = false;
            }

            return;
        }

        _isEnabled = true;
    }

    private void Update()
    {
        if (!_isEnabled)
        {
            return;
        }
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(_upKey))
        {
            direction += Vector2.up;
            _animator.SetInteger("Direction", 1);
        }

        if (Input.GetKey(_downKey))
        {
            direction += Vector2.down;
            _animator.SetInteger("Direction", 0);
        }

        if (Input.GetKey(_rightKey))
        {
            direction += Vector2.right;
            _animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(_leftKey))
        {
            direction += Vector2.left;
            _animator.SetInteger("Direction", 3);
        }

        direction.Normalize();
        _animator.SetBool("IsMoving", direction.magnitude > 0);

        _rb.velocity = _speed * direction;
    }
}
