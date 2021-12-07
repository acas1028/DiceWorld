using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DiceQuadInfo
{
    public List<int> DiceQuadColorList;

    public DiceQuadInfo()
    {
        DiceQuadColorList = new List<int>();
    }
    public void SettingDiceQuadInfo(int color)
    {
        DiceQuadColorList.Add(color);
    }

    public void ClearQuadInfo()
    {

        DiceQuadColorList.Clear();
    }
}
public class QuadManager : MonoBehaviour
{
    public GameObject DicePrefab;

    public GameObject Dice;

    public Camera camera;

    public Image DownQuadColor;
    // Start is called before the first frame update
    public DiceQuadInfo info;
    public string DiceName;

    void Start()
    {
        Dice = Instantiate(DicePrefab);
        info = new DiceQuadInfo();
    }

    // Update is called once per frame
    void Update()
    {
        DownQuadColor.color = Dice.GetComponent<DiceQuad>().DownQuad.GetComponent<MeshRenderer>().materials[0].color;

        camera.transform.position = new Vector3(Dice.transform.position.x - 3.5f, Dice.transform.position.y + 5.0f, Dice.transform.position.z - 3.5f);
    }

    public void SaveDice()
    {
        info.ClearQuadInfo();
        for (int i = 0; i < Dice.GetComponent<DiceQuad>().DiceQuadList.Count; i++)
        {
            Color diceColor = Dice.GetComponent<DiceQuad>().DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color;
            if (diceColor == TileColor.tileColorRed)
                info.SettingDiceQuadInfo(TileColor.red);
            if (diceColor == TileColor.tileColorBlue)
                info.SettingDiceQuadInfo(TileColor.blue);
            if (diceColor == TileColor.tileColorGreen)
                info.SettingDiceQuadInfo(TileColor.green);
            if (diceColor == Color.white)
                info.SettingDiceQuadInfo(TileColor.white);
            if (diceColor == Color.black)
                info.SettingDiceQuadInfo(TileColor.black);
        }

        string str = JsonUtility.ToJson(info);
        string mapName = "/Resources/Dice/" + DiceName + ".json";
        File.WriteAllText(Application.dataPath + mapName, JsonUtility.ToJson(info));
    }
}
