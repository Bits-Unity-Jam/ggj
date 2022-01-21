using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RouteBuilder : MonoBehaviour
{
    [SerializeField] private RoadPattern[] _roadPatterns;
    
    private Vector2 _pointToBuild;
    private GameObject _playerMovers;
    private float _lessDistanceToBuilde;

    private void Start()
    {
        _playerMovers = GameObject.FindGameObjectWithTag("Player");//погано, аде хз як краще
        _pointToBuild = Vector3.zero;
        BuildNextRoad();
    }

    private void Update()
    {
        if (CheckIfPlayerNear())
        {
            BuildNextRoad();
        }
    }

    private void BuildNextRoad()
    {
        var roadPattern = GetRandomRoadPattern();
        Instantiate(roadPattern.roads, _pointToBuild, Quaternion.identity);
        
        _lessDistanceToBuilde = roadPattern.GetVectorLength().magnitude;
        
        _pointToBuild += roadPattern.GetVectorLength();
    }

    private bool CheckIfPlayerNear() => (Vector2.Distance(_playerMovers.transform.position, _pointToBuild) < _lessDistanceToBuilde);


    private RoadPattern GetRandomRoadPattern() => _roadPatterns[Random.Range(0, _roadPatterns.Length)];
}