using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager Instance;
    private toolController actualTool;
    
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
    
    public void NewToolSelected(toolController tool)
    {
        if (actualTool != null)
        {
            actualTool.ResetTool();
        }
        actualTool = tool;
    }
}
