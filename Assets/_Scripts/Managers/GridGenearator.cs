using UnityEngine;

public static class GridGenearator
{
    public static Vector2[] GenerateGrid(int width, int height, float gap)
    {
        Vector2[] cells = new Vector2[width * height];

        Vector2 offset = Vector2.zero;
        
        for (int i = 0; i < height; i++)
        {
            offset.x = 0;
            for (int j = 0; j < width; j++)
            {
                Vector2 pos = new Vector2(j, i) + offset;
                cells[i * width + j] = pos;
                offset.x += gap;
            }
            offset.y += gap;
        }
        
        return cells;
    }
}
