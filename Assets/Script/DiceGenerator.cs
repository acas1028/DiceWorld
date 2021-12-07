using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiceGenerator : MonoBehaviour
{
    public GameObject DicePrefab;

    public GameObject Dice;

    public TileManager tileManager;
    public Camera camera;

    public DiceQuadInfo Diceinfo;
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

    public void GenerateDice()
    { 
        Dice = Instantiate(DicePrefab);
        Diceinfo = new DiceQuadInfo();

        Vector3 dicePosition = new Vector3(tileManager.TileList[tileManager.Start_Point].transform.position.x, tileManager.TileList[tileManager.Start_Point].transform.position.y + 0.5f, tileManager.TileList[tileManager.Start_Point].transform.position.z);
        Dice.transform.position = dicePosition;

        Dice.GetComponent<MoveDice>().currentDicePosition = tileManager.Start_Point;
        TextAsset dicetext = Resources.Load(DiceName) as TextAsset;
        Debug.Log(dicetext.ToString());
        Diceinfo = JsonUtility.FromJson<DiceQuadInfo>(dicetext.ToString());
    }

    IEnumerator ResetDice()
    {
        Destroy(Dice);

        yield return new WaitForSeconds(2.0f);

        GenerateDice();
    }

    public void CResetDice()
    {
        StartCoroutine(ResetDice());
    }


}
