using UnityEngine;

public class Bomb : Tile
{
    public override string Name => "Bomb";

    protected override void OnClickAction()
    {
        foreach (Tile tile in TilesManager.Instance.tiles)
        {
            if (tile == null)
                continue;

            if (!tile.gameObject.IsBomb())
                continue;

            tile.GetComponent<SpriteRenderer>().color = Color.red;
        }

        Helpers.RestartLevel();
    }
}