using System;
using UnityEngine;

public class bigWoundsCollider : MonoBehaviour
{
    [SerializeField] private BigWoundsController bigWoundController;
    
    private bool isMouseOver = false;

    private void Update()
    {
        print("is mouse over: " + isMouseOver);
        if(!isMouseOver){return;}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space key was pressed while mouse is over the object.");
            bigWoundController.HealWound();
        }
    }


    private void OnMouseOver()
    {
        isMouseOver = true;
    }
    
    private void OnMouseExit()
    {
        isMouseOver = false;
    }   
}
