using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
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

    public void DeletePreviousRoute(PathCreator[] previosRoute)
    {
        /*StartCoroutine(UnActivateRoute(previosRoute));*/ //не правильна передача масиву усіх доріг
    }

    private IEnumerator UnActivateRoute(PathCreator[] routes)
    {
        yield return new WaitForSeconds(5);
        foreach (var route in routes)
        {
            route.gameObject.SetActive(false);
        }
        
    }
    private GameObject GetRandomRoute() => _routes[Random.Range(0, _routes.Length)];
    
}
