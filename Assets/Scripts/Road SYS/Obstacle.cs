using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerMover playerMover))
        {
            GameManager.instance.ToEndGame();
        }
    }
}
