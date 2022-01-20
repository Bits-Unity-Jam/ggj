using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RouteBuilder : MonoBehaviour
{
    [SerializeField] private RoadPattern[] _roadPatterns;
    private Vector2 _pointToBuilde;

    private void Start()
    {
        _pointToBuilde = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuildNextRoad();
        }
    }

    public void BuildNextRoad()
    {
        var roadPattern = GetRandomRoadPattern();
        Instantiate(roadPattern.roads, _pointToBuilde, Quaternion.identity);
        _pointToBuilde += roadPattern.GetVectorLength();
    }

    private RoadPattern GetRandomRoadPattern() => _roadPatterns[Random.Range(0, _roadPatterns.Length-1)];
}