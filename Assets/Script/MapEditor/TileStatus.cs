using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStatus : MonoBehaviour
{
    public GameObject Flag;

    public bool isTileFree;
    public bool isTileGoal;
    // Start is called before the first frame update
    void Start()
    {
        isTileFree = false;
        isTileGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
   

    }

    public void SettingFlag()
    {
        GameObject Dummy = GameObject.FindWithTag("Flag");

        if (Dummy != null) Destroy(Dummy);

        Debug.Log("ÇÃ·¡±× ¸¸µë");
        GameObject flag = Instantiate(Flag);
        flag.transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
    }
}
