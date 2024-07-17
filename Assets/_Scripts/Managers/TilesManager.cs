using System.Linq;
using UnityEngine;

public class TilesManager : Singleton<TilesManager>
{
    public GameObject[] cells;
    public Tile[] tiles;
    public Plate[] plates;
    public Bomb[] bombs;

    public void CheckAllBombsFlagged()
    {
        int flagsCount = tiles.ToList().Count(t => t.GetState() == TileState.Flagged);
        flagsCount += bombs.ToList().Count(t => t.GetState() == TileState.Flagged);

        if (flagsCount != bombs.Length)
            return;

        foreach (Bomb bomb in bombs)
        {
            bomb.Explode();
        }

        EndScreen.Instance.Win();
    }
}
