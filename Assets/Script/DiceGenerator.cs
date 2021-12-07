using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GenerateDice();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dice == null) return;
        camera.transform.position = new Vector3(Dice.transform.position.x - 3.5f, Dice.transform.position.y + 5.0f, Dice.transform.position.z - 3.5f);
    }

    public void GenerateDice()
    {
      
        Dice = Instantiate(DicePrefab);
        Diceinfo = new DiceQuadInfo();

        Vector3 dicePosition = new Vector3(tileManager.TileList[tileManager.Start_Point].transform.position.x, tileManager.TileList[tileManager.Start_Point].transform.position.y + 0.5f, tileManager.TileList[tileManager.Start_Point].transform.position.z);
        Dice.transform.position = dicePosition;

        TextAsset dicetext = Resources.Load(DiceName) as TextAsset;
        Debug.Log(dicetext.ToString());
        Diceinfo = JsonUtility.FromJson<DiceQuadInfo>(dicetext.ToString());
    }

    IEnumerator ResetDice()
    {
        yield return new WaitForSeconds(2.0f);

        GenerateDice();
    }

    public void CResetDice()
    {
        StartCoroutine(ResetDice());
    }


}
