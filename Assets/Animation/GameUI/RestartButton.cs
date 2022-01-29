using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private void OnEnable()
    {
        StartCoroutine(Subscribing());
    }

    private void OnGameEnd()
    {
        GetComponentInChildren<Text>().color = new Color(255, 255, 255, 255);
    }

    private void OnButtoncklick()
    {
        SceneManager.LoadScene(0);
    }
    
    private  IEnumerator Subscribing()
    {
        yield return new WaitUntil(() => GameManager.IsEnabled && GameManager.IsAwaked && GameManager.IsStarted);
        DoRestartButtonSubscribtion();
        
        void DoRestartButtonSubscribtion()
        {
            GameManager.instance.GameEnd += OnGameEnd;
            _button.onClick.AddListener(OnButtoncklick);
        }
    }
}
