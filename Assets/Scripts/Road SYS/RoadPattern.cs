using System;
using UnityEngine;

[Serializable]
public class RoadPattern:MonoBehaviour
{
    public GameObject roads;
    [SerializeField]private Vector2 startPoint;
    [SerializeField]private Vector2 endPoint;

    public Vector2 GetVectorLength() => endPoint - startPoint;//для обрахунку точки спавну для наступної дороги
}