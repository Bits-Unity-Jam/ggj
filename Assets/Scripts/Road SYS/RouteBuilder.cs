using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RouteBuilder : MonoBehaviour
{
    [SerializeField] private RoadPattern[] _roadPatterns;
    
    private Vector2 _pointToBuild;
    private GameObject[] _playerMovers;
    private float _lessDistanceToBuilde;


    private void Start()
    {
        _playerMovers = GameObject.FindGameObjectsWithTag("Player");//погано, аде хз як краще
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
        Instantiate(roadPattern.roads, _pointToBuild, Quaternion.identity,gameObject.transform);

        _lessDistanceToBuilde = roadPattern.GetVectorLength().magnitude;
        _pointToBuild += roadPattern.GetVectorLength();
    }

    private bool CheckIfPlayerNear()
    {
        foreach (var player in _playerMovers)
        {
            if (Vector2.Distance(player.transform.position, _pointToBuild) < _lessDistanceToBuilde)
            {
                return true;
            }
        }
        return false;
    }
    

    private RoadPattern GetRandomRoadPattern() => _roadPatterns[Random.Range(0, _roadPatterns.Length)];
}