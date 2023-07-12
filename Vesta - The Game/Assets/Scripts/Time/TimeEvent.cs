using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class TimeEvent : MonoBehaviour
{
    private TimeTracker TimeTracker;
    private bool isTriggered = false;
    private void Awake()
    {
        TimeTracker = GameObject.FindGameObjectWithTag(Tags.TimeTacker).GetComponent<TimeTracker>();
        var meshrenderer = GetComponentInChildren<MeshRenderer>();
        meshrenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered || other.gameObject.layer != Layers.Player)
            return;

        isTriggered = true;
        TimeTracker.AddEntry(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("ColisionEnter");
        if (other.gameObject.layer != Layers.Player)
            return;
        
        TimeTracker.AddEntry(gameObject);
    }
}
