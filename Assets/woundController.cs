using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.U2D;

public class woundController : MonoBehaviour
{
    [SerializeField] private SpriteShapeObjectPlacement spriteShapeObjectPlacement;


    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Foldout("REFERENCES")]
    [SerializeField] private List<Sprite> woundSprite;
    [Foldout("REFERENCES")]
    [SerializeField] private Sprite healedWoundSprite;
    [Foldout("REFERENCES")]
    [SerializeField] private BoxCollider2D boxCollider2D;


    private void OnValidate()
    {
        UpdateWoundSprite();
    }

    private void Start()
    {
        UpdateWoundSprite();
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
        
        boxCollider2D.enabled = false;
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sortingOrder -= 1;

        }
        _healed = true;
        GetComponent<Animator>().Play("CloseWound");
        StartCoroutine(CoolDownAnimationCloseWound());  
    }

    public void UpdateWoundSprite()
    {
        if(_spriteRenderer == null) return;
        int random = UnityEngine.Random.Range(0, 2);
        if (random == 0)
        {
            _spriteRenderer.flipX = true;
        }
        if (_healed)
        {
            _spriteRenderer.sprite = healedWoundSprite;
            return;
        }
        _spriteRenderer.sprite = woundSprite[UnityEngine.Random.Range(0, woundSprite.Count)];
        //print("UPDATE WOUND SPRITE");
    }

    public void ResetWound()
    {
        boxCollider2D.enabled = true;
        _healed = false;
        UpdateWoundSprite();
    }

    private IEnumerator CoolDownAnimationCloseWound()
    {
        yield return new WaitForSeconds(0.3f);
        print("END ANIMATION CLOSE WOUND");
        UpdateWoundSprite();
    }
}
