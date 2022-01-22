using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteButton : MonoBehaviour
{
    [SerializeField] private float PauseY;
    [SerializeField] private float ContinueY;
    private void Start()
    {
        GameManager.instance.PauseGame += ToPause;
        GameManager.instance.ContinueGame += ToContinue;
    }

    private void OnDisable()
    {
        GameManager.instance.PauseGame -= ToPause;
        GameManager.instance.ContinueGame -= ToContinue;
    }
    public void ToPause()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), PauseY, 0.1f);
    }

    public  void ToContinue()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), ContinueY, 0.1f);
    }
}
