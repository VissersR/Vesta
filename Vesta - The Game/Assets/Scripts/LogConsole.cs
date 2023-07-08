using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogConsole : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI console;
    [SerializeField] 
    private int maxLenght;
    
    private List<string> _logMessages = new List<string>();
         
    void OnEnable() {
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string condition, string stacktrace, LogType type)
    {
        LogMessage(condition);
    }

    void OnDisable() {
        Application.logMessageReceived -= HandleLog;
    }

    private void LogMessage(string message)
    {
        if (_logMessages.Count >= maxLenght)
        {
            _logMessages.RemoveAt(0);
        }
        _logMessages.Add(message);

        console.text = string.Join("\n", _logMessages);
    }
}