using UnityEngine;

public class InputController : MonoBehaviour
{
    public PixelGridModel model;
    public GridRenderer gridRenderer;

    private KeyCode[] keySequence = {
        KeyCode.W, KeyCode.A, KeyCode.UpArrow, 
        KeyCode.LeftArrow, KeyCode.DownArrow, 
        KeyCode.RightArrow, KeyCode.S 
    };

    void Update()
    {
        for (int i = 0; i < keySequence.Length; i++)
        {
            if (Input.GetKeyDown(keySequence[i]) && i < model.columns)
            {
                model.inputLine[i] = !model.inputLine[i];
                gridRenderer.RenderInputLine();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            gridRenderer.CommitInputAndShift();
        }
    }
}