using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void NewToolSelected()
    {
        
    }
}
