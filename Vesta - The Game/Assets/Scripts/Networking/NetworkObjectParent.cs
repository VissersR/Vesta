using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using Unity.VisualScripting;
using UnityEngine;

public class NetworkObjectParent : MonoBehaviour
{
    private void Awake()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            var networkObjectComponent = child.AddComponent<NetworkObject>();
            networkObjectComponent.SynchronizeTransform = true;
            var networkTransform = child.AddComponent<NetworkTransform>();
        }
    }
}
