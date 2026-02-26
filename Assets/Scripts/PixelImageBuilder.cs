using UnityEngine;
using UnityEngine.UI;

public class PixelImageBuilder : MonoBehaviour
{
    [Header("Parents (RectTransforms)")]
    public RectTransform gridParent;
    public RectTransform inputLineParent;

    [Header("Prefab")]
    public GameObject pixelPrefab;

    [Header("Grid Size")]
    public int rows = 10;
    public int columns = 7;

    [Header("Optional Features")]
    [Tooltip("If enabled, grid pixels will get random colors on start.")]
    public bool randomizeOnStart = false;

    [HideInInspector] public Image[] gridPixels;
    [HideInInspector] public Image[] inputPixels;

    void Awake()
    {
        BuildGrid();
        BuildInputLine();

        if (randomizeOnStart)
        {
            RandomizeGridColors();
        }
    }

    void BuildGrid()
    {
        gridPixels = new Image[rows * columns];
        int index = 0;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject go = Instantiate(pixelPrefab, gridParent);
                go.name = $"Grid_{y}_{x}";

                Image img = go.GetComponent<Image>();
                gridPixels[index++] = img;
            }
        }
    }

    void BuildInputLine()
    {
        inputPixels = new Image[columns];

        for (int i = 0; i < columns; i++)
        {
            GameObject go = Instantiate(pixelPrefab, inputLineParent);
            go.name = $"Input_Q{i}";

            inputPixels[i] = go.GetComponent<Image>();
        }
    }

    void RandomizeGridColors()
    {
        foreach (var pixel in gridPixels)
        {
            pixel.color = new Color(
                Random.value,
                Random.value,
                Random.value
            );
        }
    }
}
