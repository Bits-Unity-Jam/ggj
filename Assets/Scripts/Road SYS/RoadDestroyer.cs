using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestroyer : MonoBehaviour
{
    [SerializeField] private Vector3 _offSet;
    private void LateUpdate()
    {
        transform.position = _offSet + Camera.main.transform.position;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out RoadPattern roadPattern))
        {
            Destroy(other.gameObject);
        }
    }
}
