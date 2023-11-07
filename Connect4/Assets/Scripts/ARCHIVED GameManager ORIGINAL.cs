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
        for(int row = 0; row < 6; row++)
        {
            for(int col = 0; col <= 3; col++)
            {
                for(int i = 0; i < 4; i++)
                {
                    Vector3Int tilePosition = new Vector3Int(col + i, row, 0);
                    TileBase tile = gameBoard.GetTile(tilePosition);
                    Vector3 worldPosition = gameBoard.GetCellCenterWorld(tilePosition);
                    Collider2D[] colliders = Physics2D.OverlapPointAll(worldPosition);
                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.gameObject.tag == "P1")
                        {
                            Debug.Log("Red wins!");
                        }
                        else if (collider.gameObject.tag == "P2")
                        {
                            Debug.Log("Yellow wins!");
                        }
                    }
                }
            }
        }
    }
}
