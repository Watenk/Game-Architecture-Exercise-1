using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Tile[,] Grid;

    //Scriptable Object
    [SerializeField]
    private GridGenerationSettings gridGenerationSettings;
    [SerializeField]
    private TilesSettings tilesSettings;

    void Start()
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

    public void SetTile(Vector2Int pos, TileSettingsData tileData)
    {
        CheckIfOutOfBounds(pos);

        Grid[pos.x, pos.y].TileData.Id = tileData.Id;

        //Replace spriteObject
        Destroy(Grid[pos.x, pos.y].TileData.SpriteObject);
        GameObject instantiatedSprite = Instantiate(tileData.SpriteObject, new Vector3(pos.x, -pos.y, 0), Quaternion.identity);
        instantiatedSprite.transform.SetParent(this.transform);

        Grid[pos.x, pos.y].TileData.SpriteObject = instantiatedSprite;
    }

    public void CheckIfOutOfBounds(Vector2Int pos)
    {
        if (pos.x < 0 || pos.x > gridGenerationSettings.GridSize.x || pos.y < 0 || pos.y > gridGenerationSettings.GridSize.y)
        {
            Debug.LogError("Grid Access Out Of Bounds At: " + pos.x + ", " + pos.y);
        }
    }

    ////////////////////////////////////////////////////////////

    private void CreateTile(Vector2Int pos, TileSettingsData tileData)
    {
        CheckIfOutOfBounds(pos);

        GameObject instantiatedSprite = Instantiate(tileData.SpriteObject, new Vector3(pos.x, -pos.y, 0), Quaternion.identity);
        instantiatedSprite.transform.SetParent(this.transform);

        Grid[pos.x, pos.y] = new Tile(pos, gridGenerationSettings.TileSize, new TileSettingsData(tileData.Id, instantiatedSprite, tileData.MaxHealth));
    }

    //Fill the Grid array with GridTiles and instantiate GridSprites
    private void InitializeGrid()
    {
        Grid = new Tile[gridGenerationSettings.GridSize.x, gridGenerationSettings.GridSize.y];

        for (int y = 0; y < gridGenerationSettings.GridSize.y; y++)
        {
            for (int x = 0; x < gridGenerationSettings.GridSize.x; x++)
            {
                CreateTile(new Vector2Int(x, y), tilesSettings.Floor);
            }
        }
    }

    private void GenerateMap()
    {
        for (int y = 0; y < gridGenerationSettings.GridSize.y; y++)
        {
            for (int x = 0; x < gridGenerationSettings.GridSize.x; x++)
            {
                //Outer Walls
                if (y == 0 || x == 0 || y == gridGenerationSettings.GridSize.y - 1 || x == gridGenerationSettings.GridSize.x - 1)
                {
                    SetTile(new Vector2Int(x, y), tilesSettings.Wall);
                }

                //Inner Walls
                if (Random.Range(1, 100) <= gridGenerationSettings.WallAmount)
                {
                    SetTile(new Vector2Int(x, y), tilesSettings.Wall);
                }

                //Enemy's
                if (Random.Range(1, 100) <= gridGenerationSettings.EnemyAmount)
                {

                }
            }
        }
    }
}