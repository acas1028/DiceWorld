using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCameraFollow : MonoBehaviour
{
    public GameObject Dice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dice = GameObject.FindWithTag("OtherDice");

        if (Dice == null) return;
        transform.position = new Vector3(Dice.transform.position.x - 3.5f, Dice.transform.position.y + 5.0f, Dice.transform.position.z - 3.5f);
    }
}
