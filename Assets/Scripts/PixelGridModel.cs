using UnityEngine;

public class PixelGridModel : MonoBehaviour
{
    public int rows = 10;
    public int columns = 7;

    public bool[,] grid;
    public bool[] inputLine;

    void Awake()
    {
        grid = new bool[rows, columns];
        inputLine = new bool[columns];
    }

    public void ClearInputLine()
    {
        for (int i = 0; i < columns; i++)
            inputLine[i] = false;
    }
}
