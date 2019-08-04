using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVisual : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private ShipData _currentShipData;

    public ShipData Data
    {
        get { return _currentShipData; }
    }

    public void SetData(ShipData data)
    {
        _currentShipData = data;

        if (_currentShipData != null)
        {
            transform.position = _currentShipData.Position;
        }
    }
}
