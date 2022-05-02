using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoubleDiceGenerator : MonoBehaviour
{
    public GameObject DicePrefab;

    public GameObject Dice_Start;
    public GameObject Dice_End;

    public TileManager tileManager;

    public Camera camera;

    public DiceQuadInfo Diceinfo_Start;
    public DiceQuadInfo Diceinfo_End;

    public GameObject DiceChanger;

    public string DiceName;
    // Start is called before the first frame update
    void Start()
    {
        CResetDice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateDiceStart()
    {

        Dice_Start = Instantiate(DicePrefab);
        Diceinfo_Start = new DiceQuadInfo();

        Vector3 dicePosition = new Vector3(tileManager.TileList[tileManager.Start_Point].transform.position.x, tileManager.TileList[tileManager.Start_Point].transform.position.y + 0.5f, tileManager.TileList[tileManager.Start_Point].transform.position.z);
        Dice_Start.transform.position = dicePosition;

        Dice_Start.GetComponent<MoveDoubleDice>().currentDicePosition = tileManager.Start_Point;
        Dice_Start.tag = "Dice";

        TextAsset dicetext = Resources.Load(DiceName) as TextAsset;
        Debug.Log(dicetext.ToString());
        Diceinfo_Start = JsonUtility.FromJson<DiceQuadInfo>(dicetext.ToString());
    }

    public void GenerateDiceEnd()
    {

        Dice_End = Instantiate(DicePrefab);
        Diceinfo_End = new DiceQuadInfo();

        Vector3 dicePosition = new Vector3(tileManager.TileList[tileManager.End_Point].transform.position.x, tileManager.TileList[tileManager.End_Point].transform.position.y + 0.5f, tileManager.TileList[tileManager.End_Point].transform.position.z);
        Dice_End.transform.position = dicePosition;

        Dice_End.GetComponent<MoveDoubleDice>().currentDicePosition = tileManager.End_Point;
        Dice_Start.tag = "OtherDice";

        TextAsset dicetext = Resources.Load(DiceName) as TextAsset;
        Debug.Log(dicetext.ToString());
        Diceinfo_End = JsonUtility.FromJson<DiceQuadInfo>(dicetext.ToString());
    }

    IEnumerator ResetDice()
    {
        Destroy(Dice_Start);
        Destroy(Dice_End);

        yield return new WaitForSeconds(2.0f);

        GenerateDiceStart();
        GenerateDiceEnd();

        Dice_Start.GetComponent<MoveDoubleDice>().isActivated = true;
        Dice_End.GetComponent<MoveDoubleDice>().isActivated = false;

        DiceChanger.GetComponent<DoubleDiceChanger>().ChangeCamera();
    }

    public void CResetDice()
    {
        StartCoroutine(ResetDice());
    }
}
