using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUI : MonoBehaviour
{
    protected GameManager _gameManager;

    protected void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    protected void OnEnable()
    {
        StartCoroutine(Subscribing());
    }

    protected void OnDisable()
    {
        GameManager.instance.PauseGame -= OnPause;
        GameManager.instance.ContinueGame -= OnContinue;
    }

    protected virtual IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => _gameManager.IsEnabled && _gameManager.IsAwaked && _gameManager.IsStarted);

        DoBaseSubscribtion();

        void DoBaseSubscribtion()
        {
            GameManager.instance.PauseGame += OnPause;
            GameManager.instance.ContinueGame += OnContinue;
        }
    }
    protected abstract void OnPause();
    protected abstract void OnContinue();

}
