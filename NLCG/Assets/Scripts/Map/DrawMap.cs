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

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if((x % 2 == 0 && y % 2 != 0) || (y % 2 ==0 && x % 2 != 0))
                {
                    tile.GetComponent<SpriteRenderer>().sprite = sprites[1];
                }
                else
                {
                    tile.GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
                GameObject newTile = Instantiate(tile, new Vector3(x, y, 0), tile.transform.rotation);
                tiles[x, y] = newTile;
            }
        }
    }
}
