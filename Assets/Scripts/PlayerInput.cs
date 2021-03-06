using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _playerMover.currentDirection = Directions.up;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            _playerMover.currentDirection = Directions.down;
        }
        else
        {
            _playerMover.currentDirection = Directions.forward;
        }
    }
}
