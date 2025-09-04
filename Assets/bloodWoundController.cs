using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodWoundController : MonoBehaviour
{
    [SerializeField] private  List<Sprite> woundsSprites;

    
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Start()
    {
        UpdateWoundsSprite();
        StartCoroutine(BloodWoodLife());
    }

    public void UpdateWoundsSprite()
    {
        spriteRenderer.sprite = woundsSprites[Random.Range(0, woundsSprites.Count)];
    }

    private IEnumerator BloodWoodLife()
    {
        yield return new WaitForSeconds(2.5f);
        // END PSSSTT
        GetComponent<Animator>().Play("CloseBloodWound");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
