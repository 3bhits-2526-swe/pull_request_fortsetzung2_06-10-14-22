using UnityEngine;

public class GridLogic : MonoBehaviour
{
    public PixelGridModel model;
    public GridRenderer gridRenderer;

    public void PushInputLine()
    {
        for (int y = model.rows - 1; y > 0; y--)
        {
            for (int x = 0; x < model.columns; x++)
            {
                model.grid[y, x] = model.grid[y - 1, x];
            }
        }

        for (int x = 0; x < model.columns; x++)
        {
            model.grid[0, x] = model.inputLine[x];
        }

        model.ClearInputLine();
        gridRenderer.RenderAll();
    }
}
