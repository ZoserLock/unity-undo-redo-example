using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private Button _addButton;

    [SerializeField]
    private Button _undoButton;

    [SerializeField]
    private Button _redoButton;

    protected override bool DestroyOnLoad()
    {
        return false;
    }

    protected override void OnAwake()
    {
        _addButton.onClick.AddListener(OnAdd);
        _undoButton.onClick.AddListener(OnUndo);
        _redoButton.onClick.AddListener(OnRedo);
    }


    private void OnAdd()
    {
        EditorManager.Instance.CreateNewShip();
    }

    private void OnUndo()
    {
        CommandManager.Instance.Undo();
    }

    private void OnRedo()
    {
        CommandManager.Instance.Redo();
    }
}
