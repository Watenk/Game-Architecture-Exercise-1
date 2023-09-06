using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GridTile[,] Grid;

    public Vector2Int GridSize;
    public Vector2Int TileSize;
    public GameObject SpritePrefab;

    void Start()
    {
        InitializeGrid(GridSize, TileSize);
        GenerateMap();
    }

    void Update()
    {
        
    }

    //Fill the Grid array with GridTiles and instantiate GridSprites
    private void InitializeGrid(Vector2Int gridSize, Vector2Int tileSize)
    {
        Grid = new GridTile[gridSize.x, gridSize.y];

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                //Sprite
                GameObject spriteGameObject = Instantiate(SpritePrefab, new Vector3(x, -y, 0), Quaternion.identity);
                spriteGameObject.transform.SetParent(this.transform);
                
                //Tile
                Grid[x, y] = new GridTile(new Vector2Int(x, y), new Vector2Int(tileSize.x, tileSize.y), new GridSprite(spriteGameObject));
            }
        }
    }

    private void GenerateMap()
    {

    }
}
