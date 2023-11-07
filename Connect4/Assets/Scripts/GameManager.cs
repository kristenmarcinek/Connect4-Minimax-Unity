using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected Tilemap gameBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinCondition();
    }

    public void WinCondition()
    {
        // Check horizontal win condition
        for(int row = 0; row < 6; row++)
        {
            for(int col = 0; col <= 3; col++)
            {
                if (CheckWinCondition(new Vector3Int(col, row, 0), Vector3Int.right))
                {
                    return;
                }
            }
        }

        // Check vertical win condition
        for(int row = 0; row <= 2; row++)
        {
            for(int col = 0; col < 7; col++)
            {
                if (CheckWinCondition(new Vector3Int(col, row, 0), Vector3Int.up))
                {
                    return;
                }
            }
        }

        // Check diagonal win condition (top-left to bottom-right)
        for(int row = 0; row <= 2; row++)
        {
            for(int col = 0; col <= 3; col++)
            {
                if (CheckWinCondition(new Vector3Int(col, row, 0), new Vector3Int(1, 1, 0)))
                {
                    return;
                }
            }
        }

        // Check diagonal win condition (bottom-left to top-right)
        for(int row = 3; row < 6; row++)
        {
            for(int col = 0; col <= 3; col++)
            {
                if (CheckWinCondition(new Vector3Int(col, row, 0), new Vector3Int(1, -1, 0)))
                {
                    return;
                }
            }
        }
    }

    private bool CheckWinCondition(Vector3Int startTile, Vector3Int direction)
    {
        string currentTag = "";
        int count = 0;

        for(int i = 0; i < 4; i++)
        {
            Vector3Int tilePosition = startTile + i * direction;
            TileBase tile = gameBoard.GetTile(tilePosition);
            Vector3 worldPosition = gameBoard.GetCellCenterWorld(tilePosition);
            Collider2D[] colliders = Physics2D.OverlapPointAll(worldPosition);
            foreach (Collider2D collider in colliders)
            {
                if (currentTag == "")
                {
                    currentTag = collider.gameObject.tag;
                    count++;
                }
                else if (collider.gameObject.tag == currentTag)
                {
                    count++;
                }
                else
                {
                    currentTag = "";
                    count = 0;
                    break;
                }
            }
        }

        if (count == 4)
        {
            if (currentTag == "P1")
            {
                Debug.Log("Orange wins!");
            }
            else if (currentTag == "P2")
            {
                Debug.Log("Yellow wins!");
            }
            return true;
        }

        return false;
    }
}
