using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GridTile[,] Grid;

    public Vector2Int GridSize;
    public Vector2Int TileSize;

    [SerializeField]
    private GridGenerationSettings gridGenerationSettings;
    [SerializeField]
    private TileIDs tileIDs;

    void Start()
    {
        InitializeGrid(GridSize, TileSize);
        GenerateMap();
    }

    //Tiles
    ////////////////////////////////////////////////////////////
    public GridTile GetTile(Vector2Int pos)
    {
        //Implement out of bounds catcher
        return Grid[pos.x, pos.y];
    }

    public void SetTile(Vector2Int pos, Tile tile)
    {
        //Implement out of bounds catcher
        Grid[pos.x, pos.y].Pos = pos;
        Grid[pos.x, pos.y].Id = tile.Id;
        Destroy(Grid[pos.x, pos.y].Sprite);
        GameObject instantiatedSprite = Instantiate(tile.Sprite, new Vector3(pos.x, -pos.y, 0), Quaternion.identity);
        instantiatedSprite.transform.SetParent(this.transform);
        Grid[pos.x, pos.y].Sprite = tile.Sprite;
    }

    private void CreateTile(Vector2Int pos, Tile tile)
    {
        //Implement out of bounds catcher
        GameObject instantiatedSprite = Instantiate(tile.Sprite, new Vector3(pos.x, -pos.y, 0), Quaternion.identity);
        instantiatedSprite.transform.SetParent(this.transform);
        Grid[pos.x, pos.y] = new GridTile(tile.Id, instantiatedSprite, pos, new Vector2Int(TileSize.x, TileSize.y));
    }

    ////////////////////////////////////////////////////////////

    //Fill the Grid array with GridTiles and instantiate GridSprites
    private void InitializeGrid(Vector2Int gridSize, Vector2Int tileSize)
    {
        Grid = new GridTile[gridSize.x, gridSize.y];

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                CreateTile(new Vector2Int(x, y), tileIDs.Floor);
            }
        }
    }

    private void GenerateMap()
    {
        for (int y = 0; y < GridSize.y; y++)
        {
            for (int x = 0; x < GridSize.x; x++)
            {
                //Outer Walls
                if (y == 0 || x == 0 || y == GridSize.y - 1 || x == GridSize.x - 1)
                {
                    SetTile(new Vector2Int(x, y), tileIDs.Wall);
                }

                //Inner Walls
                if (Random.Range(1, 100) <= gridGenerationSettings.WallAmount)
                {
                    SetTile(new Vector2Int(x, y), tileIDs.Wall);
                }
            }
        }
    }
}