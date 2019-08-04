using GameModules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoSingleton<EditorManager>
{
    [SerializeField]
    private ShipVisual _shipVisualPrefab;

    [SerializeField]
    private Camera _mainCamera;

    private Dictionary<ShipData, ShipVisual> _visualMap = new Dictionary<ShipData, ShipVisual>();

    private ShipVisual _dragShipVisual;
    private Vector3    _dragOriginalPosition;
    private Vector3    _dragOriginalShipPosition;
    private Vector3    _dragOffset;

    protected override bool DestroyOnLoad()
    {
        return false;
    }

    protected override void OnStart()
    {
        InputManager.Instance.OnDragEvent += HandleDrag;
    }

    public void CreateNewShip()
    {
        var command = CreateShipCommand.Create();
        CommandManager.Instance.ExecuteCommand(command);
    }

    public void MoveShip(ShipData ship,Vector3 oldPos, Vector3 newPos)
    {
        var command = MoveShipCommand.Create(ship,oldPos,newPos);
        CommandManager.Instance.ExecuteCommand(command);
    }

    public void RegisterShip(ShipData data)
    {
        var shipVisual = Instantiate<ShipVisual>(_shipVisualPrefab);
        data.SetVisual(shipVisual);
        _visualMap.Add(data, shipVisual);
    }

    public void UnregisterShip(ShipData data)
    {
        if (_visualMap.Remove(data))
        {
            data.ClearVisual();
        }
    }

    public void HandleDrag(DragStatus status, Vector3 position, Vector3 last)
    {
        if (status == DragStatus.Begin)
        {
            Ray ray = _mainCamera.ScreenPointToRay(position);

            var hit = Physics2D.Raycast(ray.origin, ray.direction, 10000);

            if(hit.transform)
            {
                var shipVisual = hit.transform.GetComponent<ShipVisual>();
                if(shipVisual)
                {
                    _dragShipVisual = shipVisual;
                    _dragOriginalPosition = hit.point;
                    _dragOriginalShipPosition = shipVisual.transform.position;
                    _dragOffset = new Vector3(hit.point.x,hit.point.y, hit.transform.position.z) - hit.transform.position;
                }
            }
        }
        else if (status == DragStatus.Moving)
        {
            if (_dragShipVisual != null)
            {
                Ray ray = _mainCamera.ScreenPointToRay(position);

                Vector3 newPos = new Vector3(ray.origin.x, ray.origin.y, _dragOriginalPosition.z);
                _dragShipVisual.transform.position = _dragOriginalShipPosition + (newPos - _dragOriginalPosition);
            }
        }
        else if (status == DragStatus.End)
        {
            if (_dragShipVisual != null)
            {
                MoveShip(_dragShipVisual.Data, _dragOriginalShipPosition, _dragShipVisual.transform.position);
                _dragShipVisual = null;
            }
        }
    }
}
