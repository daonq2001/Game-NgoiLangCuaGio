using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMap : MonoBehaviour
{
    public int xSize, ySize;
    public GameObject tile;

    private GameObject[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];     // 9

        float startX = transform.position.x;     // 10
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {      // 11
            for (int y = 0; y < ySize; y++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
                tiles[x, y] = newTile;
            }
        }
    }
}
