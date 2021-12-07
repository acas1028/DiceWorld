using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceColorChange : MonoBehaviour
{
    public GameObject DiceGenerator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DiceGenerator.GetComponent<DiceGenerator>().Dice == null) return;
        DiceGenerator.GetComponent<DiceGenerator>().Dice.GetComponent<DiceQuad>().ChangeDiceColor(DiceGenerator.GetComponent<DiceGenerator>().Diceinfo);
    }
}
