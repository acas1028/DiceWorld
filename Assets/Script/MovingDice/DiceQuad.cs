using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceQuad : MonoBehaviour
{
    public List<GameObject> DiceQuadList;

    public GameObject DownQuad;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < DiceQuadList.Count; i++)
        {
            if(i == 0 || i == 1 || i == 2 || i == 3)
            {
                DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = Color.black;
            }
            if (i == 4 || i == 5)
            {
                 DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = Color.white;
             }
        }
    }

    // Update is called once per frame
    void Update()
    {
        DownQuad = CheckDownQuad();
    }

    GameObject CheckDownQuad()
    {
        GameObject min = DiceQuadList[0];
        for(int i = 0; i < DiceQuadList.Count; i++)
        {
            if(DiceQuadList[i].transform.position.y < min.transform.position.y)
            {
                min = DiceQuadList[i];
            }
        }
        return min;
    }

    public void ChangeDiceColor(DiceQuadInfo diceQuadinfo)
    {
        for(int i = 0; i < diceQuadinfo.DiceQuadColorList.Count; i++)
        {
            if (diceQuadinfo.DiceQuadColorList[i] == TileColor.black)
                DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = Color.black;
            if (diceQuadinfo.DiceQuadColorList[i] == TileColor.white)
                DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = Color.white;
            if (diceQuadinfo.DiceQuadColorList[i] == TileColor.red)
                DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorRed;
            if (diceQuadinfo.DiceQuadColorList[i] == TileColor.blue)
                DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorBlue;
            if (diceQuadinfo.DiceQuadColorList[i] == TileColor.green)
                DiceQuadList[i].GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorGreen;
        }
    }
}
