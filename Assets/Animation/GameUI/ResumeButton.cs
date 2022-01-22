using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private float PauseY;
    [SerializeField] private float ContinueY;
    
    
    private Button _continue;

    private void Awake()
    {
        _continue = GetComponent<Button>();
    }
    private void Start()
    {
        _continue.onClick.AddListener(GameManager.instance.ToContinueGame);
        _continue.onClick.AddListener(ToContinue);
        
        GameManager.instance.PauseGame += ToPause;
    }

    private void OnDisable()
    {
        GameManager.instance.PauseGame -= ToPause;
    }
    public void ToPause()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), PauseY, 0.1f);
        transform.LeanScale(Vector3.one, 0.1f);
    }

    public void ToContinue()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), ContinueY, 0.1f);
        transform.LeanScale(Vector3.zero, 0.1f);
    }
}
