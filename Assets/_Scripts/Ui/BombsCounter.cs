using TMPro;
using UnityEngine;

public class BombsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;

    private int _counter;

    private void OnEnable()
    {
        Tile.OnTileStateChanged += UpdateCounter;
    }

    private void OnDisable()
    {
        Tile.OnTileStateChanged -= UpdateCounter;
    }

    private void UpdateCounter(TileState tileState)
    {
        if (tileState == TileState.Not_Flagged)
            _counter++;
        else
            _counter--;

        UpdateCounterText();
    }

    public void SetCounter(int counter)
    {
        _counter = counter;

        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        _counterText.SetText($"Bombs Left: {_counter}");
    }
}
