using System.Collections.Generic;
using UnityEngine;

public class bloodWoundController : MonoBehaviour
{
    [SerializeField] private  List<Sprite> woundsSprites;

    
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Start()
    {
        UpdateWoundsSprite();
    }

    public void UpdateWoundsSprite()
    {
        spriteRenderer.sprite = woundsSprites[Random.Range(0, woundsSprites.Count)];
    }
}
