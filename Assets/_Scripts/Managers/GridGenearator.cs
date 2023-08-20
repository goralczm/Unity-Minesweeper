using UnityEngine;

public static class GridGenearator
{
    public static GameObject[] GenerateGrid(Transform parent, GameObject prefab, int width, int height, float gap)
    {
        if (prefab == null) return null;
        
        parent.DestroyChildren();

        GameObject[] cells = new GameObject[width * height];

        Vector2 offset = Vector2.zero;
        
        for (int i = 0; i < height; i++)
        {
            offset.x = 0;
            for (int j = 0; j < width; j++)
            {
                Vector2 pos = new Vector2(j, i) + offset;
                cells[i * width + j] = Object.Instantiate(prefab, pos, Quaternion.identity, parent);
                cells[i * width + j].name = $"Tile {i * width + j}";
                offset.x += gap;
            }
            offset.y += gap;
        }
        
        return cells;
    }
}
