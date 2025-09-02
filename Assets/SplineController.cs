using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.U2D;

public class SplineController : MonoBehaviour
{
     [SerializeField] private GameObject spriteShapePrefabs;
     private SpriteShapeController _spriteShapeController;


     [Button]
     public void CreateSpline()
     {
          var sp =  Instantiate(spriteShapePrefabs, transform);
          _spriteShapeController = sp.transform.GetComponent<SpriteShapeController>();
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
