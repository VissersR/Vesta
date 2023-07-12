using System;
using Unity.LEGO.Minifig;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private double _maxHealth;

    private MinifigController _minifigController;

    public double CurrentHealth;

    public void Awake()
    {
        _maxHealth = 100;
        CurrentHealth = _maxHealth;
        _minifigController = GetComponent<MinifigController>();
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Explode();
        }
    }

    public void TakeDamage(double amount)
    {
        CurrentHealth -= amount;
    }
    
    public void Heal(double amount)
    {
        CurrentHealth += amount;
    }

    public void Explode()
    {
        if (_minifigController)
        {
            _minifigController.Explode();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = _maxHealth;
    }
}
