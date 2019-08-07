using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData
{
    private Vector3 _position;
    private ShipVisual _visual;
    private int _textureType;

    #region Get/Set
    public Vector3 Position
    {
        get { return _position; }
        set
        {
            _position = value;
            if(_visual != null)
            {
                _visual.transform.position = _position;
            }
        }
    }

    public ShipVisual Visual
    {
        get { return _visual; }
    }

    public int TextureType
    {
        get { return _textureType; }
    }

    #endregion

    public ShipData()
    {
        _position = Random.insideUnitSphere*5;
    }

    public void SetVisual(ShipVisual visual)
    {
        if (visual != null)
        {
            _visual = visual;
            _visual.SetData(this);
        }
    }

    public void ClearVisual()
    {
        if (_visual != null)
        {
            GameObject.Destroy(_visual.gameObject);
            _visual = null;
        }
    }
}
