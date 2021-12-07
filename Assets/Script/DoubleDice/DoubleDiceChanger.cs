using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDiceChanger : MonoBehaviour
{
    public GameObject DiceGenerator;

    public GameObject MainCamera;
    public GameObject SubCamera;

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
            if (DiceStart.GetComponent<MoveDoubleDice>().isActivated)
            {
                DiceStart.GetComponent<MoveDoubleDice>().isActivated = false;
                DiceEnd.GetComponent<MoveDoubleDice>().isActivated = true;

                MainCamera.SetActive(false);
                SubCamera.SetActive(true);
            }
            else if (DiceEnd.GetComponent<MoveDoubleDice>().isActivated)
            {
                DiceEnd.GetComponent<MoveDoubleDice>().isActivated = false;
                DiceStart.GetComponent<MoveDoubleDice>().isActivated = true;

                SubCamera.SetActive(false);
                MainCamera.SetActive(true);
            }
        }
    }
}
