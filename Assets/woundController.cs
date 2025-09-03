using UnityEngine;
using UnityEngine.U2D;

public class woundController : MonoBehaviour
{
    [SerializeField] private SpriteShapeObjectPlacement spriteShapeObjectPlacement;

    public void Intialize(float ratio,SpriteShapeController spriteShapeController)
    {
        spriteShapeObjectPlacement.spriteShapeController = spriteShapeController;
        spriteShapeObjectPlacement.ratio = ratio;
    }

    public void Destroy()
    {
        DestroyImmediate(gameObject);

    }
}
