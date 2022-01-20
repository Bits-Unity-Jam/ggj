using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Serialization;

public class PlayerMover : MonoBehaviour
{ 
    [SerializeField] private PathCreator _currentPathCreator;
    [SerializeField] private float _speed;
    
    private float _distanceTravelled;

    public Directions directions { get; set; }
    public PathCreator currentPathCreator => _currentPathCreator;
    
    private void Update()
    {
        MoveByRout();
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

    
}
public enum Directions
{
    up,
    forward,
    down,
}
