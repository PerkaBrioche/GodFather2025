using UnityEngine;

public class toolController : MonoBehaviour
{
    bool canBePicked = true;
    
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void ToolsClicked()
    {
        if(!canBePicked ) return;
        
        spriteRenderer.enabled = false;
        canBePicked = false;
    }
    
    public void ResetTool()
    {
        spriteRenderer.enabled = true;
        canBePicked = true;
    }
}
