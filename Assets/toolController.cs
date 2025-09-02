using UnityEngine;

public class toolController : MonoBehaviour
{
    bool canBePicked = true;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void ToolsClicked()
    {
        if (canBePicked)
        {
            spriteRenderer.enabled = false;
            canBePicked = false;
        }
        else
        {
            
        }
    }
}
