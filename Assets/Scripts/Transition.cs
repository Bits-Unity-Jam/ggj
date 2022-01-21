using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private List<Route> _routeList;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMover playerMover))
        {
            GiveNextRoutes(playerMover,_routeList);

            Debug.Log($"{playerMover.typeControlle} == "+playerMover.currentDirection);
        }
    }
    
    private void GiveNextRoutes(PlayerMover playerMover,List<Route> routes)
    {
        var newRoute = playerMover.ChooseRoute(routes);
        playerMover.SetNewRoute(newRoute);
    }

}