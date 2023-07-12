using System;
using Constants;
using TMPro;
using UnityEngine;

namespace Time
{
    public class ScoreBoard: MonoBehaviour
    {
        private TimeTracker TimeTracker;
        
        [SerializeField]
        private TextMeshProUGUI Entry1;
        [SerializeField]
        private TextMeshProUGUI Entry2;
        [SerializeField]
        private TextMeshProUGUI Entry3;
        private void Awake()
        {
            TimeTracker = GameObject.FindGameObjectWithTag(Tags.TimeTacker).GetComponent<TimeTracker>();
        }

        private void Update()
        {
            if (TimeTracker.Finished)
            {
                Entry1.text = $"{TimeTracker.TimeEntries[0].Target.name}: {FormatTimeSpan(TimeTracker.TimeEntries[0].TimeUntil)}";
                Entry2.text = $"{TimeTracker.TimeEntries[1].Target.name}: {FormatTimeSpan(TimeTracker.TimeEntries[1].TimeUntil)}";
                Entry3.text = $"{TimeTracker.TimeEntries[2].Target.name}: {FormatTimeSpan(TimeTracker.TimeEntries[2].TimeUntil)}";
            }
        }

        public void CreateScoreBoard()
        {
            
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            return $"{timeSpan.Minutes}:{timeSpan.Seconds}.{timeSpan.Milliseconds}";
        }
    }
}