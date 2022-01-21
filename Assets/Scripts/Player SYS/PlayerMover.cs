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
    [SerializeField] private TypeControlle _typeControlle;
    [SerializeField] private float _speed;

    private PathCreator _currentPathCreator;
    private float _distanceTravelled;
    
    public Directions currentDirection { get; set; }
    public TypeControlle typeControlle => _typeControlle;
    

    private void Update()
    {
        if(_currentPathCreator!=null)MoveByRout();
    }
    

    private void MoveByRout()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        transform.position = _currentPathCreator.path.GetPointAtDistance(_distanceTravelled);
        /*transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);*/
    }

    public void SetNewRoute(PathCreator pathCreator)
    {
        _currentPathCreator = pathCreator;
        _distanceTravelled = 0;
    }

    public PathCreator ChooseRoute(List<Route> routes) //шукає дорогу яка співпадає з напрямком руху гравця, якщо нема то рандом
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
        return routeStruct.route.GetComponent<PathCreator>();
    }
}