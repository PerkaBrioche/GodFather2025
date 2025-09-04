using System.Collections;
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
    
    private bool canSpawnBlood = true;  
    private bool trySpawnBlood = false;  
    
    public CurrentZoneEnum eCurrentZone = CurrentZoneEnum.NONE;
    
    [Header("REFERENCES")]
    [SerializeField] private GameObject bloodPrefab;
    
    int hurtCount = 0;

    void Update()
    {
        print("UPDATE RAYCAST");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D pointHit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Game Zone Raycasts"));

        if (pointHit.collider != null && pointHit.collider.CompareTag("SafeZone"))
        {
            if (trySpawnBlood)
            {
                trySpawnBlood = false;
                StopCoroutine("CoolDownSafeTimeBeforeBlood");
            }
            eCurrentZone = CurrentZoneEnum.SAFE;
            Debug.Log("Safe");
        }
        else if (pointHit.collider != null && pointHit.collider.CompareTag("BloodZone"))
        {
            eCurrentZone = CurrentZoneEnum.BLOOD;
            Debug.Log("Blood!");
            TrySpawnBlood();
        }
        else 
        { 
            if (trySpawnBlood)
            {
                trySpawnBlood = false;
                StopCoroutine("CoolDownSafeTimeBeforeBlood");
            }
            eCurrentZone= CurrentZoneEnum.NONE;
            Debug.Log("no zone detected"); 
        }
    }

    public void TrySpawnBlood()
    {
        if(trySpawnBlood){return;}
        if(!canSpawnBlood){return;}

        print("TRYING TO SPAWN BLOOD");
        trySpawnBlood = true;
        StartCoroutine("CoolDownSafeTimeBeforeBlood");
    }
    
    
    private IEnumerator CoolDownBloodSpawn()
    {
        yield return new WaitForSeconds(1f);
        canSpawnBlood = true;
    }

    private void SpawnBlood()
    {
        print("SPAWN BLOOD");
        ShakeManager.instance.ShakeCamera();
        canSpawnBlood = false;
        StartCoroutine(nameof(CoolDownBloodSpawn));
        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var blood = Instantiate(bloodPrefab, spawnPosition, Quaternion.identity);
        
        hurtCount++;
        if (hurtCount >= 3)
        {
            CanvasManager.Instance.ShowSplashBloods();
            hurtCount = 0;
        }
    }

    private IEnumerator CoolDownSafeTimeBeforeBlood()
    {
        yield return new WaitForSeconds(0.6f);
        if (eCurrentZone == CurrentZoneEnum.BLOOD)
        {
            SpawnBlood();
            yield break;
        }
    }
}
