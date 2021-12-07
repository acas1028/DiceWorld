using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileColorChange : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
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
