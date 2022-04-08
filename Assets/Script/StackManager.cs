using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public int MoveCount;
    public int DeathCount;
    // Start is called before the first frame update
    void Start()
    {
        MoveCount = 0;
        DeathCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseMoveCount()
    {
        MoveCount++;
    }

    public void IncreaseDeathCount()
    {
        DeathCount++;
    }
}
