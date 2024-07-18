using UnityEngine;
using UnityEngine.Events;

public class GenerationProcess : MonoBehaviour
{
    [SerializeField] private Plate _platePrefab;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private float _cellGap;
    [SerializeField] private BombsCounter _counter;

    [SerializeField] private UnityEvent _onGameStartedEvents;

    public void MakeBoard(int width, int height, int minesCount)
    {
        Vector2[] cells = GridGenearator.GenerateGrid(width, height, _cellGap);
        CameraUtility.SetCameraPosition(cells, 2);
        CameraUtility.SetCameraScroll();
        CellAssignment.AssignTiles(cells, minesCount, transform, _platePrefab, _bombPrefab);
        CellAssignment.AssignAdjecentTiles(width);
        CellAssignment.CalculateNearbyBombs();
        PlateNaming.NamePlates();
        _counter.SetCounter(minesCount);

        _onGameStartedEvents?.Invoke();
    }
}
