using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private float _followSpeed;
    
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offSet, _followSpeed*Time.deltaTime);
    }
}
