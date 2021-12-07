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

    public ColorTileMap()
    {
        StageType = 0;
        MapScale_X = 0;
        MapScale_Y = 0;
        Tile_type = new List<int>();
        Start_Point = 0;
        End_Point = 0;
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

    Color Start_Color;
    Color End_Color;

    float StartColor_R;
    float StartColor_G;
    float StartColor_B;

    float EndColor_R;
    float EndColor_G;
    float EndColor_B;

    [SerializeField]
    int MapScale_x;
    [SerializeField]
    int MapScale_y;
    void Start()
    {
        Map = new ColorTileMap();
        Start_Color = new Color(1.0f, 0.5f, 0.0f);
        End_Color = new Color(0.0f, 0.5f, 1.0f);

        StartColor_R = 1.0f;
        StartColor_G = 0.5f;
        StartColor_B = 0.0f;

        EndColor_R = 0.0f;
        EndColor_G = 0.5f;
        EndColor_B = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Start_Color = new Color(StartColor_R, StartColor_G, StartColor_B);
        End_Color = new Color(EndColor_R, EndColor_G, EndColor_B);

        TileList[Start_Point].GetComponent<MeshRenderer>().materials[0].color = Start_Color;
        TileList[End_Point].GetComponent<MeshRenderer>().materials[0].color = End_Color;

        StartColor_R += Time.deltaTime;
        StartColor_G += Time.deltaTime;
        StartColor_B += Time.deltaTime;

        EndColor_R += Time.deltaTime;
        EndColor_G += Time.deltaTime;
        EndColor_B += Time.deltaTime;

        StartColor_R = InitializeColorValue(StartColor_R);
        StartColor_G = InitializeColorValue(StartColor_G);
        StartColor_B = InitializeColorValue(StartColor_B);

        EndColor_R = InitializeColorValue(EndColor_R);
        EndColor_G = InitializeColorValue(EndColor_G);
        EndColor_B = InitializeColorValue(EndColor_B);
    }

    public void SaveInfo()
    {

        Map.SettingMapInfo(0, MapScale_x, MapScale_y);
        Map.ClearList();
        for (int i = 0; i < MapScale_x * MapScale_y; i++)
        {
            if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == Color.red)
                Map.SettingTileInfo(TileColor.red);
            else if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == Color.green)
                Map.SettingTileInfo(TileColor.green);
            else if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == Color.blue)
                Map.SettingTileInfo(TileColor.blue);
            else if (TileList[i].GetComponent<MeshRenderer>().materials[0].color == Color.black)
                Map.SettingTileInfo(TileColor.black);
            else
                Map.SettingTileInfo(TileColor.white);
        }

        Map.SettingSE(Start_Point, End_Point);

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

    float InitializeColorValue(float value)
    {
        if (value < 1.0f) return value;

        return value - 1.0f;
    }
}
