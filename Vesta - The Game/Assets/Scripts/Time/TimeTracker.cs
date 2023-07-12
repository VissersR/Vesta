using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public List<TimeEntry> TimeEntries = new List<TimeEntry>();
    private DateTime StartTime;
    public TimeSpan TotalTime;
    public bool Started = false;
    public bool Finished = false;
    
    public void AddEntry(GameObject target)
    {
        TimeEntries.Add( new TimeEntry
        {
            TimeUntil = DateTime.Now - StartTime,
            Target = target
        });
    }

    private void Start()
    {
        StartTracking();
    }

    public void StartTracking()
    {
        StartTime = DateTime.Now;
        TotalTime = new TimeSpan();
        Started = true;
    }

    public void StopTracking()
    {
        Finished = true;
        Started = false;
    }

    private void Update()
    {
        if (Started)
            TotalTime = DateTime.Now - StartTime;
    }
}

public class TimeEntry
{
    public TimeSpan TimeUntil { get; set; }
    public GameObject Target { get; set; }
}
