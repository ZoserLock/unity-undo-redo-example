using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCommand : Command
{
    private string _logMessage;

    #region Get/Set
    public string LogMessage
    {
        get { return _logMessage; }
        set { _logMessage = value; }
    }
    #endregion

    public LogCommand(string message)
    {
        _logMessage = message;
    }

    public string GetName()
    {
        return "Log: " + LogMessage;
    }

    public void Execute()
    {
        Debug.LogWarning("Executed:"+LogMessage);
    }

    public void Unexecute()
    {
        Debug.LogWarning("Unexecuted:" + LogMessage);
    }

    public static LogCommand Create(string text)
    {
        return new LogCommand(text);
    }
}
