using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridRenderer : MonoBehaviour
{
    public PixelGridModel model;
    public PixelImageBuilder builder;

    void Start()
    {
        RenderAll();
    }


    public void RenderInputLine()
    {
        for (int i = 0; i < model.columns; i++)
        {
            if (i < builder.inputPixels.Length)
                builder.inputPixels[i].color = model.inputLine[i] ? Color.white : Color.black;
        }
    }

    public void CommitInputAndShift()
    {
        for (int y = model.rows - 1; y > 0; y--)
            for (int x = 0; x < model.columns; x++)
                model.grid[y, x] = model.grid[y - 1, x];

        for (int x = 0; x < model.columns; x++)
        {
            model.grid[0, x] = model.inputLine[x];
            model.inputLine[x] = false; 
        }
        RenderAll();
    }

    public void RenderGrid()
    {
        int index = 0;
        for (int y = model.rows - 1; y >= 0; y--)
        {
            for (int x = 0; x < model.columns; x++)
            {
                if (index < builder.gridPixels.Length)
                {
                    builder.gridPixels[index].color = model.grid[y, x] ? Color.white : Color.black;
                    index++;
                }
            }
        }
    }

    public void RenderAll()
    {
        RenderGrid();
        RenderInputLine();
    }
}