using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.U2D;

public class SplineController : MonoBehaviour
{
     [SerializeField] private GameObject spriteShapePrefabs;
     [SerializeField] private GameObject woundPrefabs;

     [Range(0, 30)] public int numberOfWoundsOnSpline;
     private SpriteShapeController _spriteShapeController;
     
     public List<woundController> WoundsControllers  = new List<woundController>();



     [Button]
     public void UpdateWounds()
     {
          ClearWoundsOnSpline();
          UpdateWoundsOnSpline();
     }
     
     
     private void ClearWoundsOnSpline()
     {
          foreach (var woundsController in WoundsControllers)
          {
               if (woundsController != null)
               {
                    woundsController.Destroy();
               }
          }
          WoundsControllers.Clear();
     }

     [Button]
     public void CreateSpline()
     {
          var sp =  Instantiate(spriteShapePrefabs, transform);
          _spriteShapeController = sp.transform.GetComponent<SpriteShapeController>();
          UpdateWoundsOnSpline();
     }

     public void UpdateWoundsOnSpline()
     {
          if (_spriteShapeController == null) return;
          for (int i = 0; i < numberOfWoundsOnSpline; i++)
          { 
               var wounds =  Instantiate(woundPrefabs , _spriteShapeController.transform);
              var  woundsController = wounds.GetComponent<woundController>(); 
               float ratio = ((float)i / (float)(numberOfWoundsOnSpline-1));
              woundsController.Intialize(ratio, _spriteShapeController); 
              WoundsControllers.Add(woundsController);
                   
          }
     }
     
     [Button]
     public void ClearSpline()
     {
          if (_spriteShapeController != null)
          {
               DestroyImmediate(_spriteShapeController.gameObject);
          }
          _spriteShapeController = null;

     }
}
