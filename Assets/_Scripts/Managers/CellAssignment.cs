using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CellAssignment
{
    private static int[] GetRandomBombCells(int cellsCount, int minesCount)
    {
        int[] bombIndexes = new int[minesCount];

        for (int i = 0; i < minesCount; i++)
        {
            int randomIndex = Random.Range(0, cellsCount);
            while (bombIndexes.Contains(randomIndex))
                randomIndex = Random.Range(0, cellsCount);

            bombIndexes[i] = randomIndex;
        }

        return bombIndexes;
    }

    public static void AssignTiles(GameObject[] cells, int minesCount)
    {
        Tile[] tiles = new Tile[cells.Length];
        Plate[] plates = new Plate[cells.Length - minesCount];
        Bomb[] bombs = new Bomb[minesCount];

        int[] bombIndexes = GetRandomBombCells(cells.Length, minesCount);

        int currentPlates = 0;
        int currentBombs = 0;
        for (int i = 0; i < cells.Length; i++)
        {
            if (bombIndexes.Contains(i))
            {
                tiles[i] = cells[i].AddComponent<Bomb>();
                bombs[currentBombs] = tiles[i] as Bomb;
                currentBombs++;
                continue;
            }

            tiles[i] = cells[i].AddComponent<Plate>();
            plates[currentPlates] = tiles[i] as Plate;
            currentPlates++;
        }

        TilesManager tilesManager = TilesManager.Instance;
        tilesManager.tiles = tiles;
        tilesManager.plates = plates;
        tilesManager.bombs = bombs;
    }

    public static void AssignAdjecentTiles(int gridWidth)
    {
        Tile[] tiles = TilesManager.Instance.tiles;

        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].adjecentTiles = new List<Tile>();

            bool IsLeft = i == 0 || i % gridWidth == 0;
            bool IsRight = (i + 1) % gridWidth == 0;
            bool IsDown = i < gridWidth;
            bool IsUp = i > tiles.Length - 1 - gridWidth;

            if (!IsDown)
                tiles[i].adjecentTiles.Add(tiles[i - gridWidth]);

            if (!IsUp)
                tiles[i].adjecentTiles.Add(tiles[i + gridWidth]);

            if (!IsLeft)
                tiles[i].adjecentTiles.Add(tiles[i - 1]);

            if (!IsRight)
                tiles[i].adjecentTiles.Add(tiles[i + 1]);

            if (!IsLeft && !IsDown)
                tiles[i].adjecentTiles.Add(tiles[i - gridWidth - 1]);

            if (!IsRight && !IsDown)
                tiles[i].adjecentTiles.Add(tiles[i - gridWidth + 1]);

            if (!IsLeft && !IsUp)
                tiles[i].adjecentTiles.Add(tiles[i + gridWidth - 1]);

            if (!IsRight && !IsUp)
                tiles[i].adjecentTiles.Add(tiles[i + gridWidth + 1]);
        }
    }

    public static void CalculateNearbyBombs()
    {
        Bomb[] bombs = TilesManager.Instance.bombs;

        foreach (Bomb bomb in bombs)
        {
            if (bomb.adjecentTiles == null)
                continue;

            foreach (Tile tile in bomb.adjecentTiles)
            {
                if (tile.gameObject.IsBomb())
                    continue;

                tile.GetComponent<Plate>().nearbyBombs++;
            }
        }
    }
}
