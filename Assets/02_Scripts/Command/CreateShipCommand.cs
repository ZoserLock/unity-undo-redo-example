﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShipCommand : Command
{
    private ShipData _data = null;

    public void Execute()
    {
        if(_data == null)
        {
            _data = new ShipData();
        }

        EditorManager.Instance.RegisterShip(_data);
    }

    public void Unexecute()
    {
        EditorManager.Instance.UnregisterShip(_data);
    }

    public string GetName()
    {
        return "Create Ship";
    }

    public static CreateShipCommand Create()
    {
        return new CreateShipCommand();
    }
}
