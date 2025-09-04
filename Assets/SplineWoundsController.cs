using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.U2D;

public class SplineWoundsController : MonoBehaviour
{
     public List<woundController> WoundsControllers  = new List<woundController>();
     
     public void SetWoundsControllers(List<woundController> woundsControllers)
     {
          WoundsControllers = woundsControllers;
     }

     public bool AllWoundsHealed()
     {
          foreach (var woundsController in WoundsControllers)
          {
               if(woundsController == null) continue;
               if (!woundsController.IsHealed)
               {
                    return false;
               }
          }
          return true;
     }

     public void ResetAllWounds()
     {
          foreach (var woundsController in WoundsControllers)
          {
               if (woundsController != null)
               {
                    woundsController.ResetWound();
               }
          }
     }
}
