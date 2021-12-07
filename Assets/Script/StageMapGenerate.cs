using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMapGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MapGenerator>().LoadMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
