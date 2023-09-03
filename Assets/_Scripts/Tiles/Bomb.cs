using UnityEngine;

public class Bomb : Tile
{
    public override string Name => "Bomb";

    [SerializeField] private Sprite _bombSprite;

    protected override void OnClickAction()
    {
        foreach (Bomb bomb in _tilesManager.bombs)
            bomb.Explode();

        foreach (Tile tile in _tilesManager.tiles)
            tile.enabled = false;

        EndScreen.Instance.Lose();
    }

    public void Explode()
    {
        _rend.sprite = _bombSprite;
    }
}