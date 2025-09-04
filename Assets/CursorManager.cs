using System;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    
    private cursorType actualCursorType = cursorType.aiguille;
    
    
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

    private void Start()
    {
        UpdateCursorSprite();
    }

    public void ChangeCursorType(cursorType type)
    {
        if (type == actualCursorType)
        {
            return;
        }
        actualCursorType = type;
        UpdateCursorSprite();
    }
    
    public void UpdateCursorSprite()
    {
        print("SET CURSOR");
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
