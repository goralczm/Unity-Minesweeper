using System;
using System.Collections.Generic;
using UnityEngine;

public enum TileState
{
    Not_Flagged,
    Flagged,
}

public abstract class Tile : MonoBehaviour
{
    public abstract string Name { get; }

    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _flaggedSprite;

    public List<Tile> adjecentTiles;

    protected SpriteRenderer _rend;

    private TileState _currentState;
    private float _holdTimer = .2f;
    private bool _isHolding;

    protected TilesManager _tilesManager;

    public static Action<TileState> OnTileStateChanged;

    public TileState GetState()
    {
        return _currentState;
    }

    protected abstract void OnClickAction();

    public virtual void Awake()
    {
        _rend = GetComponent<SpriteRenderer>();
        _tilesManager = TilesManager.Instance;
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

        switch (_currentState)
        {
            case TileState.Not_Flagged:
                FlagTile();
                break;
            case TileState.Flagged:
                UnflagTile();
                break;
        }
    }

    protected virtual void FlagTile()
    {
        _rend.sprite = _flaggedSprite;

        _currentState = TileState.Flagged;
        OnTileStateChanged?.Invoke(_currentState);
    }

    protected virtual void UnflagTile()
    {
        _rend.sprite = _normalSprite;
        _currentState = TileState.Not_Flagged;
        OnTileStateChanged?.Invoke(_currentState);
    }

    private void OnMouseUp()
    {
        _isHolding = false;

        if (_holdTimer <= 0)
            return;

        if (GetState() == TileState.Flagged)
            return;

        OnClickAction();
    }
}
