using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Tile[,] Grid;

    //Scriptable Object
    [SerializeField]
    private GameSettings gameSettings;

    public void Awake()
    {
        if (gameSettings == null)
        {
            Debug.LogError(this.name + " Is Missing GameSettings Reference");
        }
    }

    public void Start()
    {
        InitializeGrid();
        GenerateMap();
    }

    ////////////////////////////////////////////////////////////
    public Tile GetTile(Vector2Int pos)
    {
        CheckIfOutOfBounds(pos);

        return Grid[pos.x, pos.y];
    }

    public void SetTile(Vector2Int pos, TileData tileData)
    {
        CheckIfOutOfBounds(pos);

        //Replace Tile
        Destroy(Grid[pos.x, pos.y].gameObject);
        CreateTile(pos, tileData);
    }

    public void ResetTile(Vector2Int pos)
    {
        SetTile(pos, gameSettings.Floor);  
    }

    public void CheckIfOutOfBounds(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x > gameSettings.GridSize.x || pos.y < 0 || pos.y > gameSettings.GridSize.y)
        {
            Debug.LogError("Grid Access Out Of Bounds At: " + pos.x + ", " + pos.y);
        }
    }

    ////////////////////////////////////////////////////////////

    //Fill the Grid array with GridTiles and instantiate GridSprites
    private void InitializeGrid()
    {
        Grid = new Tile[gameSettings.GridSize.x, gameSettings.GridSize.y];

        for (int y = 0; y < gameSettings.GridSize.y; y++)
        {
            for (int x = 0; x < gameSettings.GridSize.x; x++)
            {
                CreateTile(new Vector2Int(x, y), gameSettings.Floor);
            }
        }
    }

    private void CreateTile(Vector2Int pos, TileData tileData)
    {
        CheckIfOutOfBounds(pos);

        GameObject tilePrefab = Instantiate(tileData.TilePrefab);
        tilePrefab.transform.SetParent(this.transform);

        if (tilePrefab.GetComponent<Tile>())
        {
            Tile tile = tilePrefab.GetComponent<Tile>();
            tile.Pos = pos;
            tile.MaxHealth = tileData.MaxHealth;
            tile.Health = tileData.MaxHealth;
            tile.Size = gameSettings.TileSize;
            tile.OnDied += ResetTile;
            Grid[pos.x, pos.y] = tile;
        }
        else
        {
            Debug.LogError(tilePrefab.name + " Doesn't have a Tile Component");
        }
    }

    private void GenerateMap()
    {
        for (int y = 0; y < gameSettings.GridSize.y; y++)
        {
            for (int x = 0; x < gameSettings.GridSize.x; x++)
            {
                //Outer Walls
                if (y == 0 || x == 0 || y == gameSettings.GridSize.y - 1 || x == gameSettings.GridSize.x - 1)
                {
                    SetTile(new Vector2Int(x, y), gameSettings.Wall);
                }

                //Inner Walls
                if (Random.Range(1, 100) <= gameSettings.WallAmount)
                {
                    SetTile(new Vector2Int(x, y), gameSettings.Wall);
                }

                //Enemy's
                if (Random.Range(1, 100) <= gameSettings.EnemyAmount)
                {

                }
            }
        }
    }
}