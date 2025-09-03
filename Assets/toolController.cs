using NaughtyAttributes;
using UnityEngine;

public class toolController : MonoBehaviour
{
    bool canBePicked = true;
    
    [Foldout("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void ToolsClicked()
    {
        if(!canBePicked ) return;
        
        spriteRenderer.enabled = false;
        canBePicked = false;
        
        ToolsManager.Instance.NewToolSelected(this);
    }
    
    public void ResetTool()
    {
        spriteRenderer.enabled = true;
        canBePicked = true;
    }
}
