using System;
using UnityEngine;


[Serializable]
public struct Route // для створення доріг з можливістю вказати напрям
{
    public GameObject route;
    public Directions directions;
}