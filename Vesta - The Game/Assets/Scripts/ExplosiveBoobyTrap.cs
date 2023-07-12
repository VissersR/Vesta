using System;
using System.Collections;
using System.Collections.Generic;
using Unity.LEGO.Minifig;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public double Damage;

    private void Awake()
    {
        Damage = 50;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("collision!!");
            var healthComponent = other.gameObject.GetComponent<HealthComponent>();
            if (healthComponent)
            {
                healthComponent.TakeDamage(Damage);
            }
            
        }
    }
}
