using System;
using UnityEngine;

public class woundCollider : MonoBehaviour
{
    [SerializeField] private woundController _woundController;

    internal void Heal()
    {
        Debug.Log($"Heal {transform.parent.name}");
        _woundController.HealWound();
    }

    private void OnMouseEnter()
    {
        Debug.Log("MouseEnter");
        _woundController.HealWound();
    }
}
