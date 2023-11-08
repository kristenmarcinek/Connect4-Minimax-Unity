using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected Color playerColor = new Color(255, 129, 0, 255);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnMouseDown()
    {
        GetComponent<Renderer>().material.color = playerColor;
    }

    
}
