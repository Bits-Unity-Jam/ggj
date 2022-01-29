using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public event Action GameStart,GameEnd,PauseGame,ContinueGame;
    
    public static bool IsAwaked=false;
    public static bool IsEnabled=false;
    public static bool IsStarted=false;

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
        ToStartGame();
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
