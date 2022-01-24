using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraChanger : MonoBehaviour
{
   private CinemachineVirtualCamera _CMvirtualCam;

   private void Awake()
   {
      _CMvirtualCam = GetComponentInParent<CinemachineVirtualCamera>();
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.TryGetComponent(out PlayerMover playerMover))
      {
         _CMvirtualCam.Priority = 9;
      }
   }
   
}
