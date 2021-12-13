using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileColorChange : MonoBehaviour
{
    bool isTileFree;

    float change_time;
    int colorNumber;
    // Start is called before the first frame update
    void Start()
    {
        colorNumber = 0;
        change_time = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        isTileFree = GetComponent<TileStatus>().isTileFree;

        change_time -= Time.deltaTime;

        if (change_time <= 0)
        {
            change_time = 0.1f;
            colorNumber++;

            if (colorNumber == 4) colorNumber = 0;
        }

        if (!isTileFree) return;


        if (colorNumber == 0) this.GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorRed;
        if (colorNumber == 1) this.GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorGreen;
        if (colorNumber == 2) this.GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorBlue;

    }
    
    public void ColorChange(int color)
    {
        if (color == TileColor.white)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
        if (color == TileColor.black)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.black;
        }
        if (color == TileColor.red)
        {
            GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorRed;
        }
        if (color == TileColor.green)
        {
            GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorGreen;
        }
        if (color == TileColor.blue)
        {
            GetComponent<MeshRenderer>().materials[0].color = TileColor.tileColorBlue;
        }
    }


   
}
