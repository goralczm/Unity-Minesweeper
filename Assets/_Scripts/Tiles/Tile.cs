using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public abstract string Name { get; }

    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _flaggedSprite;

    public List<Tile> adjecentTiles;
    public bool isFlagged;

    [HideInInspector] public SpriteRenderer _rend;
    private float _holdTimer = .2f;
    private bool _isHolding;

    [HideInInspector] public TilesManager _tilesManager;

    protected abstract void OnClickAction();

    protected virtual void Awake()
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

        isFlagged = !isFlagged;

        if (isFlagged)
            _rend.sprite = _flaggedSprite;
        else
            _rend.sprite = _normalSprite;

        _tilesManager.CheckAllBombsFlagged();
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
}
