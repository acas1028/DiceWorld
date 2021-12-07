using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDiceGenerator : MonoBehaviour
{
    public GameObject DicePrefab;

    public GameObject Dice_Start;
    public GameObject Dice_End;

    public TileManager tileManager;

    public Camera camera;

    public DiceQuadInfo Diceinfo;

    public string DiceName;
    // Start is called before the first frame update
    void Start()
    {
        GenerateDiceEnd();
        GenerateDiceStart();

        Dice_Start.GetComponent<MoveDice>().isActivated = true;
        Dice_End.GetComponent<MoveDice>().isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dice_Start == null) return;
        if (Dice_End == null) return;

        if (Dice_Start.GetComponent<MoveDice>().isActivated)
        {
            camera.transform.position = new Vector3(Dice_Start.transform.position.x - 3.5f, Dice_Start.transform.position.y + 5.0f, Dice_Start.transform.position.z - 3.5f);
        }

        else if(Dice_End.GetComponent<MoveDice>().isActivated)
        {
            camera.transform.position = new Vector3(Dice_End.transform.position.x - 3.5f, Dice_End.transform.position.y + 5.0f, Dice_End.transform.position.z - 3.5f);
        }
    }

    public void GenerateDiceStart()
    {

        Dice_Start = Instantiate(DicePrefab);
        Diceinfo = new DiceQuadInfo();

        Vector3 dicePosition = new Vector3(tileManager.TileList[tileManager.Start_Point].transform.position.x, tileManager.TileList[tileManager.Start_Point].transform.position.y + 0.5f, tileManager.TileList[tileManager.Start_Point].transform.position.z);
        Dice_Start.transform.position = dicePosition;

        TextAsset dicetext = Resources.Load(DiceName) as TextAsset;
        Debug.Log(dicetext.ToString());
        Diceinfo = JsonUtility.FromJson<DiceQuadInfo>(dicetext.ToString());
    }

    public void GenerateDiceEnd()
    {

        Dice_End = Instantiate(DicePrefab);
        Diceinfo = new DiceQuadInfo();

        Vector3 dicePosition = new Vector3(tileManager.TileList[tileManager.End_Point].transform.position.x, tileManager.TileList[tileManager.End_Point].transform.position.y + 0.5f, tileManager.TileList[tileManager.End_Point].transform.position.z);
        Dice_End.transform.position = dicePosition;

        TextAsset dicetext = Resources.Load(DiceName) as TextAsset;
        Debug.Log(dicetext.ToString());
        Diceinfo = JsonUtility.FromJson<DiceQuadInfo>(dicetext.ToString());
    }

    IEnumerator ResetDice()
    {
        yield return new WaitForSeconds(2.0f);

        GenerateDiceStart();
        GenerateDiceEnd();
    }

    public void CResetDice()
    {
        StartCoroutine(ResetDice());
    }
}
