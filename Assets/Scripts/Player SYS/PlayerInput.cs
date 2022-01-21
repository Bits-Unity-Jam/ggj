using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private KeyCode _keyCodeUp;
    private KeyCode _keyCodeDown;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        SetBind();
    }

    void Update()
    {
        SetPlayerMoverDiraction();
    }

    private void SetPlayerMoverDiraction()
    {

        if (Input.GetKey(_keyCodeUp))
        {
            _playerMover.currentDirection = Directions.up;
        }
        else if(Input.GetKey(_keyCodeDown))
        {
            _playerMover.currentDirection = Directions.down;
        }
        else
        {
            _playerMover.currentDirection = Directions.forward;
        }
    }

    private void SetBind()
    {
        if (_playerMover.typeControlle==TypeControlle.FirstPlayer)
        {
            _keyCodeUp = KeyCode.W;
            _keyCodeDown = KeyCode.S;
        }
        else if(_playerMover.typeControlle==TypeControlle.SecondPlayer)
        {
            _keyCodeUp = KeyCode.I;
            _keyCodeDown = KeyCode.K;
        }
    }
}