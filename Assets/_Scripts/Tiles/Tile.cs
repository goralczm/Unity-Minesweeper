using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public abstract string Name { get; }

    public List<Tile> adjecentTiles;
    public bool isFlagged;

    private SpriteRenderer _rend;
    private float _holdTimer = .2f;
    private bool _isHolding;
    
    protected abstract void OnClickAction();

    protected virtual void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isHolding)
            _holdTimer -= Time.deltaTime;
    }

    private void OnMouseDown()
    {
        _isHolding = true;
        _holdTimer = .2f;
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(1))
            return;

        isFlagged = !isFlagged;

        if (isFlagged)
            ChangeColor(Color.grey);
        else
            ChangeColor(Color.white);
    }

    private void OnMouseUp()
    {
        _isHolding = false;

        if (_holdTimer <= 0)
            return;

        if (isFlagged)
            return;

        OnClickAction();
    }

    public void ChangeColor(Color color)
    {
        _rend.color = color;
    }
}
