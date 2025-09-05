using System;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine.U2D;

public class SplineCreatorController : MonoBehaviour
{

     [Range(0, 100)] public int numberOfWoundsOnSpline;
     [Range(0, 5)] public int numberOfBigWoundsOnSpline;
     

     
     [Header("FOR SAVING SPLINES")]
     [SerializeField] private string splineName;
     
     [Header("REFERENCES")]
     [SerializeField] private Transform woundsParent;
     [SerializeField] private GameObject spriteShapePrefabs;
     [SerializeField] private GameObject woundPrefabs;
     [SerializeField] private GameObject bigWoundPrefabs;
     [SerializeField] private GameObject SplineHolder;
     [SerializeField] private SpriteShapeController _spriteShapeController;
     [SerializeField] private List<woundController> WoundsControllers  = new List<woundController>();
     [SerializeField] private List<BigWoundsController> bigWoundsControllers  = new List<BigWoundsController>();

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

          foreach (var bigWoundsController in bigWoundsControllers)
          {
               if (bigWoundsController != null)
               {
                    print("C");
                    bigWoundsController.DestroyWounds();
               }
          }
          bigWoundsControllers.Clear();
          WoundsControllers.Clear();
     }

     [Button]
     public void CreateSpline()
     {
          var sp =  Instantiate(spriteShapePrefabs, woundsParent.position, quaternion.identity ,transform);
          _spriteShapeController = sp.transform.GetComponent<SpriteShapeController>();
          UpdateWoundsOnSpline();
     }

     public void UpdateWoundsOnSpline()
     {
          if (_spriteShapeController == null) return;
          int numberOfallWounds = numberOfWoundsOnSpline + numberOfBigWoundsOnSpline;
          for (int i = 0; i < numberOfWoundsOnSpline; i++)
          { 
               var wounds =  Instantiate(woundPrefabs , _spriteShapeController.transform);
               var  woundsController = wounds.GetComponent<woundController>(); 
               float ratio = ((float)i / (float)(numberOfallWounds-1));
               woundsController.Intialize(ratio, _spriteShapeController); 
               WoundsControllers.Add(woundsController);
          }

          
     }
     
     [Button]
     public void ClearSpline()
     {
          ClearWoundsOnSpline();

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
          newSplines.transform.SetParent(SplineHolder.transform);
          
          newSplines.GetComponent<SplineWoundsController>().SetWoundsControllers(WoundsControllers);
          UnityEditor.PrefabUtility.SaveAsPrefabAsset(SplineHolder, "Assets/Resources/SplinesWound/" + splineName +".prefab");
          UnityEditor.AssetDatabase.Refresh();
          #endif

          splineName = "";
     }


     [Button]
     public void AddBigWound()
     {
          var wounds =  Instantiate(bigWoundPrefabs , _spriteShapeController.transform);
          var  woundsController = wounds.GetComponent<BigWoundsController>();
          bigWoundsControllers.Add(woundsController);
     }


}
