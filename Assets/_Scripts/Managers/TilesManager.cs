using System;
using System.Collections;
using System.Collections.Generic;
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
        Tile.OnTileStateChanged += CheckWinCondition;
    }

    private void OnDisable()
    {
        Tile.OnTileStateChanged -= CheckWinCondition;
    }
    
    private void CheckWinCondition()
    {
        if (!AreAllBombsFlagged() && !AreOnlyLeftPlatesBombs())
            return;

        foreach (Tile tile in tiles)
        {
            if (tile.GetState() == TileState.Flagged)
                tile.UnflagTile();
        }

        StartCoroutine(ExplosionSequence());

        EndScreen.Instance.Win();
    }

    private bool AreAllBombsFlagged()
    {
        int flaggedBombs = bombs.ToList().Count(t => t.GetState() == TileState.Flagged);
        int flaggedTiles = tiles.ToList().Count(t => t.GetState() == TileState.Flagged) - flaggedBombs;

        if (flaggedTiles != 0 || flaggedBombs != bombs.Length)
            return false;

        return true;
    }

    private bool AreOnlyLeftPlatesBombs()
    {
        List<Tile> notShownTiles = tiles.ToList().FindAll(t => t.gameObject.activeSelf && t.GetState() != TileState.Flagged && !t.IsShown);
        List<Tile> notShownBombs = tiles.ToList().FindAll(t => t.gameObject.activeSelf && t.GetState() != TileState.Flagged && !t.IsShown && t is Bomb);

        if (notShownTiles.Count == notShownBombs.Count)
            return true;

        return false;
    }

    public IEnumerator ExplosionSequence()
    {
        Tile.OnTileStateChanged -= CheckWinCondition;

        Bomb[] shuffledBombs = new Bomb[bombs.Length];
        bombs.CopyTo(shuffledBombs, 0);
        shuffledBombs.Shuffle();

        float explodeTime = .2f;
        foreach (Bomb bomb in shuffledBombs)
        {
            bomb.Explode();
            yield return new WaitForSeconds(explodeTime);
            explodeTime = Mathf.Max(.05f, explodeTime - .02f);
        }
    }
}
