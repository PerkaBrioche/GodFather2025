using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    void Update()
    {
        // Detect if mouse is hovering over a BloodZone or SafeZone tagged collider
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            // Check if the object has the desired tag
            if (hit.collider.CompareTag("SafeZone"))
            {
                Debug.Log("Safe");
            }

            if (hit.collider.CompareTag("BloodZone"))
            {
                Debug.Log("Blood!");
            }
        }
    }
}
