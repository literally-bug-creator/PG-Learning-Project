using System;
using UnityEngine;

public class MouseScheme : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 10f)]
    private float _speed;

    private Animator _animator;
    private Rigidbody2D _rb;

    private bool _isEnabled = false;
    private ushort _methodID = 1;

    [SerializeField] private KeyCode _moveKey;
    [SerializeField] private Camera _camera;

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

        if (Input.GetKey(_moveKey))
        {
            direction = _camera.ScreenToWorldPoint(Input.mousePosition);
            direction = direction - new Vector2(_rb.transform.position.x, _rb.transform.position.y);
        }

        direction.Normalize();

        _rb.velocity = _speed * direction;

        if (direction.x == 0f && direction.y == 0f)
        {
            _animator.SetBool("IsMoving", false);
            return;
        }

        if (direction.x < -0.4f)
        {
            _animator.SetInteger("Direction", 3);
        }

        if (direction.x > 0.4f)
        {
            _animator.SetInteger("Direction", 2);
        }

        if (direction.y > 0.4f)
        {
            _animator.SetInteger("Direction", 1);
        }

        if (direction.y < -0.4f)
        {
            _animator.SetInteger("Direction", 0);
        }

        _animator.SetBool("IsMoving", true);
    }
}
