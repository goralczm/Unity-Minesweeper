using TMPro;

public class Plate : Tile
{
    public override string Name => "Plate";
    public int nearbyBombs;

    private TextMeshPro _text;

    protected override void Awake()
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

    protected override void OnClickAction()
    {
        if (_text.gameObject.activeSelf)
            return;

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
    }
}