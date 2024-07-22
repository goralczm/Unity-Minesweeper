using TMPro;
using UnityEngine;

public class FlagsCounter : MonoBehaviour
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

    private void UpdateCounter()
    {
        _counter = Tile.FlagsLeft;

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
