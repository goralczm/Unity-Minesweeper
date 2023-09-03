using UnityEngine;

public class TilesManager : Singleton<TilesManager>
{
    public GameObject[] cells;
    public Tile[] tiles;
    public Plate[] plates;
    public Bomb[] bombs;

    public void CheckAllBombsFlagged()
    {
        foreach (Bomb bomb in bombs)
        {
            if (!bomb.isFlagged)
                return;
        }

        foreach (Bomb bomb in bombs)
        {
            bomb.Explode();
        }

        EndScreen.Instance.Win();
    }
}
