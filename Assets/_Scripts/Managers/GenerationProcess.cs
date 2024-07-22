using UnityEngine;
using UnityEngine.Events;
using Utilities.Utilities.Shapes;

public class GenerationProcess : MonoBehaviour
{
    [SerializeField] private Plate _platePrefab;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private float _cellSize;
    [SerializeField] private float _cellGap;
    [SerializeField] private FlagsCounter _counter;
    [SerializeField] private Rectangle _rectangleBorder;

    [SerializeField] private UnityEvent _onGameStartedEvents;

    public void MakeBoard(int width, int height, int minesCount)
    {
        Vector2[] cells = GridGenearator.GenerateGrid(width, height, _cellSize, _cellGap);
        CameraUtility.SetCameraPosition(cells, 2);
        CameraUtility.SetCameraScroll();
        CameraUtility.SetCameraBorder(_rectangleBorder, cells);
        CellAssignment.AssignTiles(cells, minesCount, transform, _platePrefab, _bombPrefab);
        CellAssignment.AssignAdjecentTiles(width);
        CellAssignment.CalculateNearbyBombs();
        PlateNaming.NamePlates();
        Tile.FlagsLeft = minesCount;
        _counter.SetCounter(minesCount);

        _onGameStartedEvents?.Invoke();
    }
}
