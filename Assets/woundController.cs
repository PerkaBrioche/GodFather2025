using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.U2D;

public class woundController : MonoBehaviour
{
    [SerializeField] private SpriteShapeObjectPlacement spriteShapeObjectPlacement;


    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Foldout("REFERENCES")]
    [SerializeField] private Sprite woundSprite;
    [Foldout("REFERENCES")]
    [SerializeField] private Sprite healedWoundSprite;


    private void OnMouseEnter()
    {
        if(_healed){return;}
        
        HealWound();
    }

    private bool _healed;

    public bool IsHealed => _healed;
    public void Intialize(float ratio,SpriteShapeController spriteShapeController)
    {
        spriteShapeObjectPlacement.spriteShapeController = spriteShapeController;
        spriteShapeObjectPlacement.ratio = ratio;
    }

    public void Destroy()
    {
        DestroyImmediate(gameObject);

    }

    public void HealWound()
    {
        if(_healed) return;
        
        _healed = true;
        UpdateWoundSprite();
    }

    public void UpdateWoundSprite()
    {
        if (_healed)
        {
            _spriteRenderer.sprite = healedWoundSprite;
            return;
        }
        _spriteRenderer.sprite = woundSprite;
    }

    public void ResetWound()
    {
        _healed = false;
        UpdateWoundSprite();
    }
}
