using System.Linq;
using UnityEngine;

public class TilesManager : Singleton<TilesManager>
{
    public GameObject[] cells;
    public Tile[] tiles;
    public Plate[] plates;
    public Bomb[] bombs;

    private void OnEnable()
    {
        Tile.OnTileStateChanged += OnTileStateChanged;
    }

    private void OnDisable()
    {
        Tile.OnTileStateChanged -= OnTileStateChanged;
    }

    private void OnTileStateChanged(TileState tileState)
    {
        CheckAllBombsFlagged();
    }

    private void CheckAllBombsFlagged()
    {
        int flaggedBombs = bombs.ToList().Count(t => t.GetState() == TileState.Flagged);
        int flaggedTiles = tiles.ToList().Count(t => t.GetState() == TileState.Flagged) - flaggedBombs;

        if (flaggedTiles != 0 || flaggedBombs != bombs.Length)
            return;

        foreach (Bomb bomb in bombs)
        {
            bomb.Explode();
        }

        EndScreen.Instance.Win();
    }
}
