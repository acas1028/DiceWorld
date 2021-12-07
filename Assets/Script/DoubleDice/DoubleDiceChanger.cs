using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDiceChanger : MonoBehaviour
{
    public GameObject DiceGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject DiceStart = DiceGenerator.GetComponent<DoubleDiceGenerator>().Dice_Start;
            GameObject DiceEnd = DiceGenerator.GetComponent<DoubleDiceGenerator>().Dice_End;
            if (DiceStart.GetComponent<MoveDice>().isActivated)
            {
                DiceStart.GetComponent<MoveDice>().isActivated = false;
                DiceEnd.GetComponent<MoveDice>().isActivated = true;
            }
            else if (DiceEnd.GetComponent<MoveDice>().isActivated)
            {
                DiceEnd.GetComponent<MoveDice>().isActivated = false;
                DiceStart.GetComponent<MoveDice>().isActivated = true;
            }
        }
    }
}
