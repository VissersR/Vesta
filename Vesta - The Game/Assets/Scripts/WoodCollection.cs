using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollection : MonoBehaviour
{
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
        if (other.gameObject.layer != 9)
        {
            return;
        }
        
        var Inventory = other.gameObject.GetComponent<Inventory>();
        if (Inventory)
        {
            Inventory.AddWood();
        }
    }
}
