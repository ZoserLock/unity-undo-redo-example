using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShipCommand : Command
{
    private Vector3 _oldPos;
    private Vector3 _newPos;
    private ShipData _ship;

    public MoveShipCommand(ShipData ship, Vector3 oldPos, Vector3 newPos)
    {
        _ship = ship;
        _oldPos = oldPos;
        _newPos = newPos;
    }

    public void Execute()
    {
        _ship.Position = _newPos;
    }

    public void Unexecute()
    {
        _ship.Position = _oldPos;
    }

    public string GetName()
    {
        return "Move to" + _newPos;
    }

    public static MoveShipCommand Create(ShipData ship, Vector3 oldPos, Vector3 newPos)
    {
        return new MoveShipCommand(ship, oldPos, newPos);
    }
}
