using UnityEngine;

public class toolsCollider : MonoBehaviour
{
    [SerializeField] private toolController _toolController;
    
    public void ClickedOnTools()
    {
        if (_toolController != null)
        {
            _toolController.ToolsClicked();
        }
    }
    
    
}
