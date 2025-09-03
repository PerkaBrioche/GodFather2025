using System.Drawing;
using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D pointHit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Game Zone Raycasts"));


        // Check if the object has the desired tag
        if (pointHit.collider != null && pointHit.collider.CompareTag("SafeZone"))
        {
            Debug.Log("Safe");
        }
        else if (pointHit.collider != null && pointHit.collider.CompareTag("BloodZone"))
        {
            Debug.Log("Blood!");
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
