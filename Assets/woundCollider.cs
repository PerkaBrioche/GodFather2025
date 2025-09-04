using System;
using UnityEngine;

public class woundCollider : MonoBehaviour
{
    [SerializeField] private woundController _woundController;

    private void OnMouseEnter()
    {
        _woundController.HealWound();
    }
}
