using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public TileManager tileManager;
    public string fileName;
    public ColorTileMap colorTileMap;



    // Start is called before the first frame update
    void Start()
    {
        fileName = tileManager.MapName;
        LoadMap();
    }

    // Update is called once per frame
    void Update()
    {
        fileName = tileManager.MapName;
    }

    public void LoadMap()
    {
        fileName = tileManager.MapName;

        colorTileMap = new ColorTileMap();
        TextAsset maptext = Resources.Load(fileName) as TextAsset;
        Debug.Log(maptext.ToString());
        colorTileMap = JsonUtility.FromJson<ColorTileMap>(maptext.ToString());

        tileManager.SetMapScale((int)colorTileMap.MapScale_X, (int)colorTileMap.MapScale_Y);

        tileManager.Start_Point = colorTileMap.Start_Point;
        tileManager.End_Point = colorTileMap.End_Point;
        GenerateMap();
    }

    public void GenerateMap()
    {
        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        tileManager.TileList.Clear();

        for (int x = 0; x < tileManager.GetMapScale_X(); x++)
        {
            for (int y = 0; y < tileManager.GetMapScale_Y(); y++)
            {
                Vector3 tilePosition = new Vector3(-tileManager.GetMapScale_X() / 2 + 0.5f + x, 0, -tileManager.GetMapScale_Y() / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - 0.05f);
                newTile.parent = mapHolder;
                newTile.GetComponent<TileNumberSetting>().SettingTileNumber(x * tileManager.GetMapScale_X() + y);
                newTile.GetComponent<TileColorChange>().ColorChange(colorTileMap.Tile_type[x * tileManager.GetMapScale_X() + y]);
                tileManager.TileList.Add(newTile.gameObject);
                // tileManager.SetMapScale((int)tileManager.GetMapScale_X(), (int)tileManager.GetMapScale_Y());
            }
        }
    }
    
    public void ClearMap()
    {
        for(int i = 0; i < tileManager.TileList.Count; i++)
        {
            tileManager.TileList[i].GetComponent<TileColorChange>().ColorChange(TileColor.white);
        }
        tileManager.Start_Point = 0;
        tileManager.End_Point = 0;
    }

    
}
