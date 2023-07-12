using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSnatchingBoobyTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 9)
        {
            return;
        }
        
        var Inventory = other.gameObject.GetComponent<Inventory>();
        if (Inventory)
        {
            Inventory.LoseWood();
        }
    }
}
