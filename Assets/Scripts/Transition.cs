using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private PathCreator _nextPath;
    private PathCreator _priviousRoute;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMover playerMover))
        {
            GetPriviousRoute(playerMover);
            GiveNextRoute(playerMover);
            
            InformManager();
            
            Debug.Log(playerMover.directions);//
        }
    }

    private void InformManager()
    {
        var endCurrentRoute = _nextPath.path.GetPoint(_nextPath.path.NumPoints - 1);
        RouteManager.instance.GenerateNextRoute(endCurrentRoute);
            
        RouteManager.instance.DeletePreviousRoute(_priviousRoute.gameObject);
    }

    private void GetPriviousRoute(PlayerMover playerMover) => _priviousRoute = playerMover.currentPathCreator;

    private void GiveNextRoute(PlayerMover playerMover)
    {
        playerMover.SetNewRoute(_nextPath);
    }

}
