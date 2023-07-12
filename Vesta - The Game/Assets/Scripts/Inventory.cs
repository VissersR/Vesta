using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int WoodCount;
    // Start is called before the first frame update
    void Start()
    {
        WoodCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWood()
    {
        WoodCount++;
    }
    
    public void LoseWood()
    {
        WoodCount--;
    }
}
