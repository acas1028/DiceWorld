using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileNumberSetting : MonoBehaviour
{
    [SerializeField]
    private int tileNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingTileNumber(int number)
    {
        tileNumber = number;
    }
}
