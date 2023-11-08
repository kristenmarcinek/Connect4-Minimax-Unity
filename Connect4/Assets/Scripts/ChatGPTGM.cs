using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChatGPTGM : MonoBehaviour
{
    public int rows = 6; // Number of rows in the grid
    public int columns = 7; // Number of columns in the grid
    public float cellSize = 1.0f; // Size of each cell
    public Vector3 gridCenter = new Vector3(0.5f, 0, 0); // Center of the grid
    public string targetTag = "YourTag"; // The tag of the game objects to check for

    private Vector3[,] gridPositions;

    void Start()
    {
        InitializeGrid();
        CheckForWin();
    }

    void InitializeGrid()
    {
        gridPositions = new Vector3[columns, rows];

        // Calculate positions and fill the grid
        float startX = gridCenter.x - (cellSize * columns / 2.0f);
        Debug.Log(startX);
        float startY = gridCenter.y - (cellSize * rows / 2.0f);
        Debug.Log(startY);

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                float x = startX + col * cellSize;
                float y = startY + row * cellSize;

                gridPositions[col, row] = new Vector3(x, y, gridCenter.z);
            }
        }
    }

    void CheckForWin()
    {
        // Check for horizontal wins
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns - 3; col++)
            {
                if (CheckLine(col, row, Vector2.right))
                {
                    // You have a horizontal win
                    Debug.Log("Horizontal Win!");
                    return;
                }
            }
        }

        // Check for vertical wins
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows - 3; row++)
            {
                if (CheckLine(col, row, Vector2.up))
                {
                    // You have a vertical win
                    Debug.Log("Vertical Win!");
                    return;
                }
            }
        }

        // Check for diagonal wins (from bottom-left to top-right)
        for (int col = 0; col < columns - 3; col++)
        {
            for (int row = 0; row < rows - 3; row++)
            {
                if (CheckLine(col, row, new Vector2(1, 1)))
                {
                    // You have a diagonal win
                    Debug.Log("Diagonal Win!");
                    return;
                }
            }
        }

        // Check for diagonal wins (from top-left to bottom-right)
        for (int col = 0; col < columns - 3; col++)
        {
            for (int row = 3; row < rows; row++)
            {
                if (CheckLine(col, row, new Vector2(1, -1)))
                {
                    // You have a diagonal win
                    Debug.Log("Diagonal Win!");
                    return;
                }
            }
        }
    }

    bool CheckLine(int startCol, int startRow, Vector2 direction)
    {
        string tagToMatch = targetTag;
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            int col = startCol + (int)(i * direction.x);
            int row = startRow + (int)(i * direction.y);

            if (col >= 0 && col < columns && row >= 0 && row < rows)
            {
                GameObject obj = YourFunctionToGetGameObjectAtPosition(col, row); // Implement this function
                if (obj != null && obj.CompareTag(tagToMatch))
                {
                    count++;
                }
            }
        }

        return count == 4;
    }

    // Implement this function to get the GameObject at a given grid position
    GameObject YourFunctionToGetGameObjectAtPosition(int col, int row)
    {
        // You need to implement a function to retrieve the game object at a specific grid position
        // This can be done using the gridPositions array or any other method you prefer.
        // Return the game object at the given position or null if the position is empty.
        return null;
    }
}