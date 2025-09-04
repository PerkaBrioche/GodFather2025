using UnityEngine;
using UnityEngine.U2D;

public class BigWoundsController : MonoBehaviour
{
    private bool cursorOnWounds;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteShapeObjectPlacement spriteShapeObjectPlacement;
    
    [SerializeField] private ParticleSystem bloodParticleSystem;
    
    [SerializeField] private Sprite woundHealedSprite;
    
    private bool healed;
    
    public void UpdateWoundsSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    
    public void Intialize(float ratio,SpriteShapeController spriteShapeController)
    {
        spriteShapeObjectPlacement.spriteShapeController = spriteShapeController;
        spriteShapeObjectPlacement.ratio = ratio;
    }

    public void HealWound()
    {
        if(healed) return;
        
        healed = true;
        spriteRenderer.sprite = woundHealedSprite;
        bloodParticleSystem.Stop();
    }

    public void DestroyWounds()
    {
        DestroyImmediate(gameObject);
    }
}
