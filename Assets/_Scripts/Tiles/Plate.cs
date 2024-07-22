using TMPro;

public class Plate : Tile
{
    public override string Name => "Plate";

    public int nearbyBombs;

    private TextMeshPro _text;

    public override void Awake()
    {
        base.Awake();
        _text = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    public override void FlagTile()
    {
        if (_text.gameObject.activeSelf)
            return;

        base.FlagTile();
    }

    public override void OnLeftClickAction()
    {
        if (_text.gameObject.activeSelf)
        {
            if (adjecentTiles.FindAll(t => t.GetState() == TileState.Flagged).Count != nearbyBombs)
                return;

            foreach (Tile tile in adjecentTiles)
            {
                if (tile.GetState() == TileState.Flagged)
                    continue;

                if (tile is Plate)
                    ((Plate)tile).ShowPlate();
                else
                    tile.OnLeftClickAction();
            }

            return;
        }

        ShowPlate();
    }

    public void ShowPlate()
    {
        if (nearbyBombs > 0)
        {
            ShowPlateText();
            return;
        }

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (adjecentTiles == null)
            return;

        foreach (Tile tile in adjecentTiles)
        {
            if (!tile.gameObject.activeSelf)
                continue;

            if (tile.gameObject.IsBomb())
                continue;

            Plate plate = tile.GetComponent<Plate>();
            if (plate.nearbyBombs > 0)
            {
                plate.ShowPlateText();
                continue;
            }

            tile.gameObject.SetActive(false);
        }
    }

    public void SetPlateText(string text)
    {
        _text.SetText(text);
    }

    public void ShowPlateText()
    {
        _text.gameObject.SetActive(true);
        IsShown = true;
        OnTileStateChanged?.Invoke();
    }
}