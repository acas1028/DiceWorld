using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public GameObject tileManagerObject;
    public TileManager tileManager;
    public string fileName;
    public ColorTileMap colorTileMap;



    // Start is called before the first frame update
    void Start()
    {
        tileManager = tileManagerObject.GetComponent<TileManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadMap_Editor()
    {
        tileManager = tileManagerObject.GetComponent<TileManager>();

        fileName = tileManager.MapName;

        colorTileMap = new ColorTileMap();
        TextAsset maptext = Resources.Load(fileName) as TextAsset;
        Debug.Log(maptext.ToString());
        colorTileMap = JsonUtility.FromJson<ColorTileMap>(maptext.ToString());

        tileManager.SetMapScale((int)colorTileMap.MapScale_X, (int)colorTileMap.MapScale_Y);

        tileManager.Start_Point = colorTileMap.Start_Point;
        tileManager.End_Point = colorTileMap.End_Point;

        for (int i = 0; i < colorTileMap.Free_TilePoint.Count; i++)
        {
            tileManager.FreeTilePoint.Add(colorTileMap.Free_TilePoint[i]);
        }

        GenerateMap();
    }
    public void LoadMap()
    {
        tileManager = tileManagerObject.GetComponent<TileManager>();

        GameObject dataManager = GameObject.FindWithTag("DataManager");
        fileName = dataManager.GetComponent<DataManager>().MapName;

        colorTileMap = new ColorTileMap();
        TextAsset maptext = Resources.Load(fileName) as TextAsset;
        Debug.Log(maptext.ToString());
        colorTileMap = JsonUtility.FromJson<ColorTileMap>(maptext.ToString());

        dataManager.GetComponent<DataManager>().Rank_Moving = colorTileMap.Rank_Moving;

        tileManager.SetMapScale((int)colorTileMap.MapScale_X, (int)colorTileMap.MapScale_Y);

        tileManager.Start_Point = colorTileMap.Start_Point;
        tileManager.End_Point = colorTileMap.End_Point;

        for(int i = 0; i < colorTileMap.Free_TilePoint.Count; i++)
        {
            tileManager.FreeTilePoint.Add(colorTileMap.Free_TilePoint[i]);
        }
        
        GenerateMap();
    }

    public void GenerateMap()
    {
        tileManager = tileManagerObject.GetComponent<TileManager>();

        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        tileManager.TileList.Clear();

        Debug.Log(tileManager.TileList.Count);


        for (int x = 0; x < tileManager.GetMapScale_X(); x++)
        {
            Debug.Log(tileManager.GetMapScale_X());
            for (int y = 0; y < tileManager.GetMapScale_Y(); y++)
            {
                Debug.Log(tileManager.GetMapScale_Y());
                Vector3 tilePosition = new Vector3(-tileManager.GetMapScale_X() / 2 + 0.5f + x, 0, -tileManager.GetMapScale_Y() / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - 0.05f);
                newTile.parent = mapHolder;
                newTile.GetComponent<TileNumberSetting>().SettingTileNumber(x * tileManager.GetMapScale_X() + y);
                newTile.GetComponent<TileColorChange>().ColorChange(colorTileMap.Tile_type[x * tileManager.GetMapScale_X() + y]); //문제발생!
                tileManager.TileList.Add(newTile.gameObject);
                // tileManager.SetMapScale((int)tileManager.GetMapScale_X(), (int)tileManager.GetMapScale_Y());
            }
        }

        Debug.Log(tileManager.TileList.Count);

        GameObject doubledice = GameObject.FindWithTag("DiceChanger");

        if (doubledice == null)
        {
            tileManager.TileList[tileManager.End_Point].GetComponent<TileStatus>().SettingFlag();
            tileManager.TileList[tileManager.End_Point].GetComponent<TileStatus>().isTileGoal = true;
        }

        for(int i = 0; i < tileManager.TileList.Count; i++)
        {
            if(tileManager.CheckFreeTile(i))
                tileManager.TileList[i].GetComponent<TileStatus>().isTileFree = true;
        }
        Debug.Log("타일바꿔보리기");
        tileManager.TileList[0].GetComponent<TileStatus>().isTileFree = true;
        Debug.Log(tileManager.TileList[0].GetComponent<TileStatus>().isTileFree);
    }

    public void GenerateNewMap()
    {
        tileManager = tileManagerObject.GetComponent<TileManager>();

        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        tileManager.TileList.Clear();

        Debug.Log(tileManager.TileList.Count);


        for (int x = 0; x < tileManager.GetMapScale_X(); x++)
        {
            Debug.Log(tileManager.GetMapScale_X());
            for (int y = 0; y < tileManager.GetMapScale_Y(); y++)
            {
                Debug.Log(tileManager.GetMapScale_Y());
                Vector3 tilePosition = new Vector3(-tileManager.GetMapScale_X() / 2 + 0.5f + x, 0, -tileManager.GetMapScale_Y() / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - 0.05f);
                newTile.parent = mapHolder;
                newTile.GetComponent<TileNumberSetting>().SettingTileNumber(x * tileManager.GetMapScale_X() + y);
                tileManager.TileList.Add(newTile.gameObject);
                // tileManager.SetMapScale((int)tileManager.GetMapScale_X(), (int)tileManager.GetMapScale_Y());
            }
        }

        Debug.Log(tileManager.TileList.Count);

        GameObject doubledice = GameObject.FindWithTag("DiceChanger");

        if (doubledice == null)
        {
            tileManager.TileList[tileManager.End_Point].GetComponent<TileStatus>().SettingFlag();
            tileManager.TileList[tileManager.End_Point].GetComponent<TileStatus>().isTileGoal = true;
        }

        for (int i = 0; i < tileManager.TileList.Count; i++)
        {
            if (tileManager.CheckFreeTile(i))
                tileManager.TileList[i].GetComponent<TileStatus>().isTileFree = true;
        }
        Debug.Log("타일바꿔보리기");
        tileManager.TileList[0].GetComponent<TileStatus>().isTileFree = true;
        Debug.Log(tileManager.TileList[0].GetComponent<TileStatus>().isTileFree);
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
