using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDiceColorChanger : MonoBehaviour
{
    public GameObject DiceGenerator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DiceGenerator.GetComponent<DoubleDiceGenerator>().Dice_Start == null) return;
        DiceGenerator.GetComponent<DoubleDiceGenerator>().Dice_Start.GetComponent<DiceQuad>().ChangeDiceColor(DiceGenerator.GetComponent<DoubleDiceGenerator>().Diceinfo_Start);

        if (DiceGenerator.GetComponent<DoubleDiceGenerator>().Dice_End == null) return;
        DiceGenerator.GetComponent<DoubleDiceGenerator>().Dice_End.GetComponent<DiceQuad>().ChangeDiceColor(DiceGenerator.GetComponent<DoubleDiceGenerator>().Diceinfo_End);
    }
}
