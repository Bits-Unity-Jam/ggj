using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private List<Route> _routeList;
    
    private GameObject[] _priviousRoutes;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMover playerMover))
        {
            /*GetPreviousRoute(playerMover);*/
            var currentPath=GiveNextRoutes(playerMover,_routeList);
            
            InformManager(currentPath); //тре налагодити предачу всіх шляхів
            
            Debug.Log(playerMover.currentDirection);//
        }
    }

    private void InformManager(PathCreator currentPath)
    {
        var endCurrentRoute = currentPath.path.GetPoint(currentPath.path.NumPoints - 1);
        RouteManager.instance.GenerateNextRoute(endCurrentRoute);
            
        /*RouteManager.instance.DeletePreviousRoute(_priviousRoutes);*/
    }

    /*private void GetPreviousRoute(PlayerMover playerMover) => _priviousRoutes = playerMover.allAvailableleRoute;*/

    private PathCreator GiveNextRoutes(PlayerMover playerMover,List<Route> routes)
    {
        var newRoute = playerMover.ChooseRoute(routes);
        playerMover.SetNewRoute(newRoute);
        return newRoute;
    }

}

[Serializable]
public struct Route // для створення доріг з можливістю вказати напрям
{
    public GameObject route;
    public Directions directions;
}
