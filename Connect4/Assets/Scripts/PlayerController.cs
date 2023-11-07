using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected GameObject redPiece;
    [SerializeField] protected Tilemap gameBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int cellPosition = gameBoard.WorldToCell(mousePosition);

        Vector3 cellCenter = gameBoard.GetCellCenterWorld(cellPosition);
        
        Instantiate(redPiece, cellCenter, Quaternion.identity);
    }
}
