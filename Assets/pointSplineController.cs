using System;
using TMPro;
using UnityEngine;

public class pointSplineController : MonoBehaviour
{
    private int _index;
    [SerializeField] private TextMeshPro _indexText;
    
    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            UpdateIndexText();
        } 
    }

  
    private void UpdateIndexText()
    {
        if (_indexText != null)
        {
            _indexText.SetText(_index.ToString());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
