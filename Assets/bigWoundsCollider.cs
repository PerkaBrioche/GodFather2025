using System;
using UnityEngine;

public class bigWoundsCollider : MonoBehaviour
{
    [SerializeField] private BigWoundsController bigWoundController;
    
    private bool isMouseOver = false;

    private void Update()
    {
        if(!isMouseOver){return;}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bigWoundController.HealWound();
        }
    }


    private void OnMouseOver()
    {
        isMouseOver = true;
        CursorManager.Instance.ChangeCursorType(CursorManager.cursorType.bobine);
    }
    
    private void OnMouseExit()
    {
        isMouseOver = false;
        CursorManager.Instance.ChangeCursorType(CursorManager.cursorType.aiguille);
    }   
}
