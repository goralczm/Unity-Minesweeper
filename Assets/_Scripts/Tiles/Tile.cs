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
    public bool IsShown { get; protected set; }

    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _flaggedSprite;

    public List<Tile> adjecentTiles = new List<Tile>();

    [SerializeField] protected SpriteRenderer _rend;

    private TileState _currentState;
    private float _holdTimer = .2f;
    private bool _isHolding;

    protected TilesManager _tilesManager;

    public static int FlagsLeft;

    public static Action OnTileStateChanged;

    public TileState GetState()
    {
        return _currentState;
    }

    public abstract void OnLeftClickAction();

    public virtual void Awake()
    {
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
        if (Input.GetMouseButtonDown(1))
        {
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
    }

    public virtual void FlagTile()
    {
        if (FlagsLeft <= 0)
            return;

        _rend.sprite = _flaggedSprite;

        _currentState = TileState.Flagged;
        FlagsLeft--;
        OnTileStateChanged?.Invoke();
    }

    public virtual void UnflagTile()
    {
        _rend.sprite = _normalSprite;
        _currentState = TileState.Not_Flagged;
        FlagsLeft++;
        OnTileStateChanged?.Invoke();
    }

    private void OnMouseUp()
    {
        _isHolding = false;

        if (_holdTimer <= 0)
            return;

        if (GetState() == TileState.Flagged)
            return;

        OnLeftClickAction();
    }
}
