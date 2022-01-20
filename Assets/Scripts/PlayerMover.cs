using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PathCreation;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerMover : MonoBehaviour
{ 
    [SerializeField] private PathCreator _currentPathCreator;
    [SerializeField] private float _speed;

    private Rigidbody2D _playerRb;
    
    private float _distanceTravelled;

    public Directions currentDirection { get; set; }
    public PathCreator[] allAvailableleRoute { get; private set; }

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveByRout();
    }
    

    private void MoveByRout()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        //transform.position = _currentPathCreator.path.GetPointAtDistance(_distanceTravelled);
        _playerRb.MovePosition(_currentPathCreator.path.GetPointAtDistance(_distanceTravelled));
        /*transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);*/
    }

    public void SetNewRoute(PathCreator pathCreator)
    {
        _currentPathCreator = pathCreator;
        _distanceTravelled = 0;
    }

    public PathCreator ChooseRoute(List<Route> routes) //шукає дорогу яка співпадає з напрямком руху гравця, якщо нема то та яка прямо
    {
        Route routeStruct;
        if (routes.Where(i=>i.directions==currentDirection).Count()!=0)
        {
            routeStruct = routes.First(i => i.directions == currentDirection);
        }
        else
        {
            routeStruct = routes[Random.Range(0,routes.Count)];
        }
        //allAvailableleRoute[0] = routeStruct.route.GetComponent<PathCreator>();//тре поміняти
        return routeStruct.route.GetComponent<PathCreator>();
    }
}
public enum Directions
{
    up,
    forward,
    down,
}
