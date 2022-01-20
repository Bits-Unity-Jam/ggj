using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using Random = UnityEngine.Random;

public class RouteManager : MonoBehaviour
{
    private const float timeToDestroy = 7;
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

    public void DeletePreviousRoute(GameObject[] previosRoute)
    {
        StartCoroutine(UnActivateRoute(previosRoute)); 
    }

    private IEnumerator UnActivateRoute(GameObject[] routes)
    {
        yield return new WaitForSeconds(timeToDestroy);
        foreach (var route in routes)
        {
            route.SetActive(false);
        }
        
    }
    private GameObject GetRandomRoute() => _routes[Random.Range(0, _routes.Length)];
    
}
