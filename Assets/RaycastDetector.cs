using System.Drawing;
using UnityEngine;

public enum CurrentZoneEnum
{
    SAFE,
    BLOOD,
    NONE
}

public class RaycastDetector : MonoBehaviour
{
    public CurrentZoneEnum eCurrentZone = CurrentZoneEnum.NONE;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D pointHit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Game Zone Raycasts"));


        // Check if the object has the desired tag
        if (pointHit.collider != null && pointHit.collider.CompareTag("SafeZone"))
        {
            eCurrentZone = CurrentZoneEnum.SAFE;
            Debug.Log("Safe");
        }
        else if (pointHit.collider != null && pointHit.collider.CompareTag("BloodZone"))
        {
            eCurrentZone = CurrentZoneEnum.BLOOD;
            Debug.Log("Blood!");
        }
        else 
        { 
            eCurrentZone= CurrentZoneEnum.NONE;
            Debug.Log("no zone detected"); 
        }
    }

    //void OnDrawGizmos()
    //{
    //    if (Camera.main == null) return;
    //    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Gizmos.color = UnityEngine.Color.red;
    //    Gizmos.DrawWireSphere(mousePos, circleRadius);
    //}
}
