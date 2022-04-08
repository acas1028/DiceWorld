using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ColorTileMap
{
    public int StageType;
    public int MapScale_X;
    public int MapScale_Y;
    public List<int> Tile_type;
    public int Start_Point;
    public int End_Point;
    public List<int> Free_TilePoint;
    public int Rank_Moving;

    public ColorTileMap()
    {
        StageType = 0;
        MapScale_X = 0;
        MapScale_Y = 0;
        Tile_type = new List<int>();
        Start_Point = 0;
        End_Point = 0;
        Free_TilePoint = new List<int>();
        Rank_Moving = 0;
    }
    public void SettingMapInfo(int stageType,int mapScale_X,int mapScale_Y)
    {
        StageType = stageType;
        MapScale_X = mapScale_X;
        MapScale_Y = mapScale_Y;
    }

    public void SettingTileInfo(int tileColor)
    {
        Tile_type.Add(tileColor);
    }

    public void SettingSE(int Start,int End)
    {
        Start_Point = Start;
        End_Point = End;
    }

    public void SettingFreeTile(int freeTile)
    {
        Free_TilePoint.Add(freeTile);
    }

    public void ClearFreeTileList()
    {
        Free_TilePoint.Clear();
    }

    public void ClearList()
    {
        Tile_type.Clear();
    }
}

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> TileList;
    public ColorTileMap Map;
    public string MapName;
    public int Start_Point;
    public int End_Point;
    public List<int> FreeTilePoint;


    [SerializeField]
    int MapScale_x;
    [SerializeField]
    int MapScale_y;
    void Start()
    {
        Map = new ColorTileMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        UpdateFreeTile();
    }

    public void SaveInfo()
    {

        Map.SettingMapInfo(0, MapScale_x, MapScale_y);
        Map.ClearList();
        Map.ClearFreeTileList();
        for (int i = 0; i < MapScale_x * MapScale_y; i++)
        {
            if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == TileColor.tileColorRed)
                Map.SettingTileInfo(TileColor.red);
            else if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == TileColor.tileColorGreen)
                Map.SettingTileInfo(TileColor.green);
            else if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == TileColor.tileColorBlue)
                Map.SettingTileInfo(TileColor.blue);
            else if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == Color.black)
                Map.SettingTileInfo(TileColor.black);
            else
                Map.SettingTileInfo(TileColor.white);
        }

        Map.SettingSE(Start_Point, End_Point);

        for(int i = 0; i < FreeTilePoint.Count; i++)
        {
            Map.SettingFreeTile(FreeTilePoint[i]);
        }

        string str = JsonUtility.ToJson(Map);

        Debug.Log(str);

        string mapName = "/Resources/" + MapName + ".json";
        File.WriteAllText(Application.dataPath + mapName, JsonUtility.ToJson(Map));

    }

    public void SetMapScale(int x, int y)
    {
        MapScale_x = x;
        MapScale_y = y;
    }

    public int GetMapScale_X()
    {
        return MapScale_x;
    }

    public int GetMapScale_Y()
    {
        return MapScale_y;
    }

    public bool CheckFreeTile(int tilePosition)
    {
        for(int i = 0; i < FreeTilePoint.Count; i++)
        {
            if (tilePosition == FreeTilePoint[i])
                return true;
        }

        return false;
    }

    public void ResetFreeTile()
    {
        FreeTilePoint.Clear();

        for(int i = 0; i < TileList.Count; i++)
        {
            if (TileList[i].GetComponent<TileStatus>().isTileFree)
                FreeTilePoint.Add(i);
        }
    }
    public void UpdateFreeTile()
    {
        for(int i = 0; i < TileList.Count; i++)
        {
            for(int j = 0; j < FreeTilePoint.Count; j++)
            {
                if(i == FreeTilePoint[j])
                {
                    TileList[i].GetComponent<TileStatus>().isTileFree = true;
                }
            }
        }
    }

    public void ResetEndTile()
    {
        for(int i = 0; i < TileList.Count; i++)
        {
            TileList[i].GetComponent<TileStatus>().isTileGoal = false;
        }
        TileList[End_Point].GetComponent<TileStatus>().isTileGoal = true;
    }
}
