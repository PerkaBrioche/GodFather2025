using System;
using UnityEngine;

public class winScreenController : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            GameManager.Instance.NewGame();
            enabled = false;
        }
    }
}
