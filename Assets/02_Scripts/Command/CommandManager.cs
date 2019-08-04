using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoSingleton<CommandManager>
{
    private List<Command> _undoList = new List<Command>();
    private List<Command> _redoList = new List<Command>();

    public void Clear()
    {
        _undoList.Clear();
        _redoList.Clear();
    }

    public void ExecuteCommand(Command command)
    {
        command.Execute();
        _undoList.Add(command);
        _redoList.Clear();
    }

    public void Undo()
    {
        if (CanPerformUndo())
        {
            Command command = _undoList[_undoList.Count - 1];

            Debug.Log("Performing UNDO for command: "+command.GetName());

            _undoList.RemoveAt(_undoList.Count - 1);

            command.Unexecute();

            _redoList.Insert(0,command);
        }
    }

    public void Redo()
    {
        if (CanPerformRedo())
        {
            Command command = _redoList[0];

            Debug.Log("Performing REDO for command: "+command.GetName());

            _redoList.RemoveAt(0);

            command.Execute();

            _undoList.Add(command);
        }
    }

    public bool CanPerformUndo()
    {
        return _undoList.Count != 0;
    }

    public bool CanPerformRedo()
    {
        return _redoList.Count != 0;
    }

    // Function from the singleton class.
    protected override bool DestroyOnLoad()
    {
        return false;
    }
}
