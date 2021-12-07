using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewMap : MonoBehaviour
{
    public InputField MapName_input;
    public InputField MapScaleX_Input;
    public InputField MapScaleY_Input;

    public string MapName;
    public int MapScale_X;
    public int MapScale_Y;

    public TileManager tileManager;
    public MapGenerator mapGenerator;
    public EditControlManager cursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MapName = MapName_input.text;
        MapScale_X = int.Parse(MapScaleX_Input.text);
        MapScale_Y = int.Parse(MapScaleY_Input.text);

    }

    public void GenerateNewMap()
    {

        
        tileManager.MapName = MapName;
        tileManager.SetMapScale(MapScale_X, MapScale_Y);
        tileManager.Start_Point = 0;
        tileManager.End_Point = 0;

        mapGenerator.GenerateMap();
        tileManager.SaveInfo();

        cursor.ResetSelectedNumber();
    }
}
