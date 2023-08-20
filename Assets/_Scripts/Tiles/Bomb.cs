using UnityEngine;

public class Bomb : Tile
{
    public override string Name => "Bomb";

    protected override void OnClickAction()
    {
        foreach (Bomb bomb in TilesManager.Instance.bombs)
            bomb.ChangeColor(Color.red);

        foreach (Tile tile in TilesManager.Instance.tiles)
            tile.enabled = false;

        EndScreen.Instance.Show();
    }
}