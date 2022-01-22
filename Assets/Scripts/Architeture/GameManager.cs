using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public event Action GameStart,GameEnd,PauseGame,ContinueGame;
    
    public bool IsAwaked=false;
    public bool IsEnabled=false;
    public bool IsStarted=false;

    private void Awake()
    {
        if(instance!=null)
            Destroy(this.gameObject);
        instance = this;
        
        IsAwaked = true;
    }

    private void OnEnable()
    {
        IsEnabled = true;
    }

    private void Start()
    {
        IsStarted = true;
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
        GameEnd?.Invoke();
    }
    public void ToPauseGame()
    {
        PauseGame?.Invoke();
    }
    
    public void ToContinueGame()
    {
        ContinueGame?.Invoke();
    }

}
