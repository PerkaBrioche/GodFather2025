using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine.U2D;

public class SplineCreatorController : MonoBehaviour
{

     [Range(0, 30)] public int numberOfWoundsOnSpline;
     
     private SpriteShapeController _spriteShapeController;
     private List<woundController> WoundsControllers  = new List<woundController>();
     
     [Header("FOR SAVING SPLINES")]
     [SerializeField] private string splineName;

     [Header("REFERENCES")]
     [SerializeField] private GameObject spriteShapePrefabs;
     [SerializeField] private GameObject woundPrefabs;


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
          var sp =  Instantiate(spriteShapePrefabs, Vector3.zero, quaternion.identity ,transform);
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

     [Button]
     public void SaveSplineWounds()
     {
          if(splineName == ""){
               Debug.LogError("Please enter a name for the spline");
               return;
          }
          #if UNITY_EDITOR
          var newSplines = _spriteShapeController.gameObject;
          newSplines.GetComponent<SplineWoundsController>().SetWoundsControllers(WoundsControllers);
          UnityEditor.PrefabUtility.SaveAsPrefabAsset(newSplines, "Assets/Resources/SplinesWound/" + splineName +".prefab");
          UnityEditor.AssetDatabase.Refresh();
          #endif

          splineName = "";
     }
     
}
