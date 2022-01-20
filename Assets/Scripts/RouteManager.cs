using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RouteManager : MonoBehaviour
{
    public static RouteManager instance { get; private set;} 
    
    [SerializeField] private GameObject[] _routes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GenerateNextRoute(Vector2 startPoint)
    {
        Instantiate(GetRandomRoute(), startPoint, Quaternion.identity);
    }

    public void DeletePreviousRoute(GameObject previosRoute)//доробити
    {
        StartCoroutine(UnActivateRoute(previosRoute));
    }

    private IEnumerator UnActivateRoute(GameObject route)
    {
        yield return new WaitForSeconds(5);
        route.SetActive(false);
    }
    private GameObject GetRandomRoute() => _routes[Random.Range(0, _routes.Length)];
    
}
