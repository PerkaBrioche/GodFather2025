using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        var ray = Camera.main.ScreenPointToRay(pos);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, 1000f, LayerMask.GetMask("Wound"));
        Debug.Log(ray);
        Debug.Log(hit);
        if (hit.collider!=null)
        {
            Debug.Log("raycats");
            hit.collider.GetComponent<woundCollider>()?.Heal();
        }
    }
}
