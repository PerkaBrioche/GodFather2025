using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class mouseCircle : MonoBehaviour
{

    Vector3 prevPosition;
    Vector3 currentPosition;

    [SerializeField] GameObject prefab;
    [SerializeField] float _stitchDistance=2f;
    [SerializeField] float _stitchDuration=100f;

    [SerializeField] RaycastDetector raycastDetector;

    // Update is called once per frame
    void Update()
    {
        if (raycastDetector.eCurrentZone == CurrentZoneEnum.NONE) return;

        currentPosition = Input.mousePosition;

        if (Vector3.Distance(prevPosition, currentPosition) < _stitchDistance)
        {
            return;
        }
        var camPosition = Camera.main.ScreenToWorldPoint(currentPosition);
        transform.position = new Vector3(camPosition.x, camPosition.y, 10);

        var dx =  prevPosition.x - currentPosition.x;
        var dy =  prevPosition.y - currentPosition.y;
        var angle = Mathf.Atan2(dy, dx);
        var angleDeg = Mathf.Rad2Deg * angle;

        prevPosition = currentPosition;

        var go = Instantiate(prefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angleDeg)));
        Destroy(go, _stitchDuration);

    }
}
