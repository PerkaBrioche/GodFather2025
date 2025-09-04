using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    
    private cursorType actualCursorType = cursorType.bobine;
    
    
    [SerializeField] private Texture2D bobineCursor;
    [SerializeField] private Texture2D aiguilleCursor;
    public enum cursorType
    {
        bobine,
        aiguille,
    }
    
    
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

    public void ChangeCursorType(cursorType type)
    {
        if (type == cursorType.bobine)
        {
            return;
        }

        actualCursorType = type;
        UpdateCursorSprite();
        
    }
    
    public void UpdateCursorSprite()
    {
        
        if (actualCursorType == cursorType.bobine)
        {
            // set cursor
            Cursor.SetCursor(bobineCursor, Vector2.zero, CursorMode.Auto);
            return;
        }
        if (actualCursorType == cursorType.aiguille)
        {
            Cursor.SetCursor(aiguilleCursor, Vector2.zero, CursorMode.Auto);
            return;
        }
    }
    
    
}
