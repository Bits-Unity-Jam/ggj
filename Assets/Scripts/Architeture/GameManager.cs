using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public event Action GameStart,GameEnd;
    
    private void Awake()
    {
        if(instance!=null)
            Destroy(this.gameObject);

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ToStartGame();
        }
    }

    public void ToStartGame()
    {
        GameStart?.Invoke();
    }
    
    public void ToEndGame()
    {
        GameEnd.Invoke();
    }
}