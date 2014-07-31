﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private bool _isFacingRight;
    private CharacterController2D _controller;
    private float _normalizedHorizontalSpeed;

    private float MaxSpeed = 10;
    private float SpeedAccellerationOnGround = 10f;

    private Animator _animator;

    public bool IsBig = false;
    public bool IsDead = false;
    private bool holdingJump = false;
    private int jumpTime = 0;
    private int maxJumpTime = 10;


    public void Start()
    {
        _controller = GetComponent<CharacterController2D>();
        _animator = GetComponent<Animator>();
        _isFacingRight = transform.localScale.x > 0;
    }

    public void Update()
    {
        HandleInput();

        _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime * SpeedAccellerationOnGround));

        _animator.SetBool("IsGrounded", _controller.State.IsGrounded);
        _animator.SetBool("IsFalling", _controller.Velocity.y < 0);
        _animator.SetBool("IsBig", IsBig);

        GameManager.Instance.distanceTraveled = transform.position.x;

        if (IsDead)
        {
            GameManager.Instance.Reset();
        }
    }

    private void HandleInput()
    {
        // always be running
        //_normalizedHorizontalSpeed = 1;
        _normalizedHorizontalSpeed = 0;

        if (Input.GetKey(KeyCode.A))
        {
            _normalizedHorizontalSpeed = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _normalizedHorizontalSpeed = 1;
        }

        if (holdingJump && jumpKey() && jumpTime-- > 0)
        {
            _controller.Jump();
        }
        else
        {
            holdingJump = false;
        }

        if (_controller.State.IsGrounded && startJumpKey())
        {
            _controller.Jump();
            holdingJump = true;
            jumpTime = maxJumpTime;
        }

    }


    private bool startJumpKey()
    {
        return Input.GetKeyDown(KeyCode.Space) || startTouch();
    }

    private bool jumpKey()
    {
        return Input.GetKey(KeyCode.Space) || touch();
    }

    private bool startTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }
    private bool touch()
    {
        if (Input.touchCount > 0)
        {
            return true;
        }
        return false;
    }


}
