using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrawMap : MonoBehaviour
{
    public int xSize, ySize;
    public GameObject tile;
    public List<Sprite> sprites;
    
    private GameObject[,] tiles;

    
    void Start()
    {
        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];     

        float startX = transform.position.x;     
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {      
            for (int y = 0; y < ySize; y++)
            {
                if(y == 0 || x == 0 || y == xSize - 1 || x == ySize - 1)
                {
                    tile.GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
                else
                {
                    tile.GetComponent<SpriteRenderer>().sprite = sprites[1];
                }
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
                
            }
        }
    }
}
