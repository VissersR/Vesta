using System;
using Constants;
using TMPro;
using UnityEngine;

namespace Time
{
    public class TimeTrackingUI: MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI TotalTime;

        private TimeTracker TimeTracker;

        private void Awake()
        {
            TimeTracker = GameObject.FindGameObjectWithTag(Tags.TimeTacker).GetComponent<TimeTracker>();
        }

        private void Update()
        {
            if (TimeTracker.Started)
                TotalTime.text =
                    $"Elapsed: {TimeTracker.TotalTime.Minutes}:{TimeTracker.TotalTime.Seconds}.{TimeTracker.TotalTime.Milliseconds}";//TimeTracker.TotalTime.ToString(@"mm\:ss.fff");
        }
    }
}