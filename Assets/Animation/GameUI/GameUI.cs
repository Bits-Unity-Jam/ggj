using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUI : MonoBehaviour
{
    protected GameManager GameManager;

    protected void Awake()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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

    private  IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => GameManager.IsEnabled && GameManager.IsAwaked && GameManager.IsStarted);

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
