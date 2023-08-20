using TMPro;

public class Plate : Tile
{
    public override string Name => "Plate";
    public int nearbyBombs;

    private TextMeshPro _text;

    private void Awake()
    {
        _text = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    protected override void OnClickAction()
    {
        if (nearbyBombs > 0)
        {
            ShowPlateText();
            return;
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (adjecentTiles == null)
            return;

        foreach (Tile tile in adjecentTiles)
        {
            if (tile == null)
                continue;

            if (tile.gameObject.IsBomb())
                continue;

            Plate plate = tile.GetComponent<Plate>();
            if (plate.nearbyBombs > 0)
            {
                plate.ShowPlateText();
                continue;
            }

            Destroy(tile.gameObject);
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