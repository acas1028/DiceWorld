using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoubleDice : MonoBehaviour
{
    public GameObject SuccessEffect;
    public GameObject FailEffect;
    public int speed = 300;
    bool isMoving = false;

    public bool isActivated = false;

    GameObject downQuad;
    TileManager tileManager;
    DoubleDiceGenerator diceGenerator;

    public int currentDicePosition;

    private void Start()
    {
        tileManager = GameObject.Find("TileManager").GetComponent<TileManager>();
        diceGenerator = GameObject.Find("DiceGenerator").GetComponent<DoubleDiceGenerator>();
    }
    void Update()
    {

        downQuad = GetComponent<DiceQuad>().DownQuad;

        if (isActivated) return;

        if (isMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentDicePosition > tileManager.GetMapScale_X() * (tileManager.GetMapScale_Y() - 1) - 1) return;
            currentDicePosition += tileManager.GetMapScale_X();

            StartCoroutine(Roll(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentDicePosition < tileManager.GetMapScale_X()) return;
            currentDicePosition -= tileManager.GetMapScale_X();

            StartCoroutine(Roll(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentDicePosition % tileManager.GetMapScale_X() == 0) return;
            currentDicePosition -= 1;

            StartCoroutine(Roll(Vector3.back));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (currentDicePosition % tileManager.GetMapScale_X() == tileManager.GetMapScale_X() - 1) return;
            currentDicePosition += 1;

            StartCoroutine(Roll(Vector3.forward));
        }
    }

    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);



        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        if (CheckMove())
        {
            GameObject effect = GameObject.Instantiate(SuccessEffect);
            effect.transform.position = new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z);
            Destroy(effect, 1.0f);

            GameObject stackManager = GameObject.FindGameObjectWithTag("StackManager");
            if (stackManager != null) stackManager.GetComponent<StackManager>().IncreaseMoveCount();
        }
        else
        {
            GameObject effect = GameObject.Instantiate(FailEffect);
            effect.transform.position = transform.position;
            Destroy(effect, 1.0f);
            diceGenerator.CResetDice();

            GameObject stackManager = GameObject.FindGameObjectWithTag("StackManager");
            if (stackManager != null) stackManager.GetComponent<StackManager>().IncreaseDeathCount();

        }

        isMoving = false;
    }

    bool CheckMove()
    {
        Debug.Log(downQuad.GetComponent<MeshRenderer>().materials[0].color);
        Debug.Log(tileManager.TileList[currentDicePosition].GetComponent<MeshRenderer>().materials[0].color);

        if(diceGenerator.Dice_Start.GetComponent<MoveDoubleDice>().currentDicePosition == diceGenerator.Dice_End.GetComponent<MoveDoubleDice>().currentDicePosition)
        {
            GameObject effect = GameObject.Instantiate(SuccessEffect);
            effect.transform.position = new Vector3(transform.position.x, transform.position.y - 0.45f, transform.position.z);
            Destroy(effect, 1.0f);

            Destroy(diceGenerator.Dice_Start);
            Destroy(diceGenerator.Dice_End);
            StageControl.Instance.ActiveUI();
        }

        if (currentDicePosition == tileManager.End_Point || currentDicePosition == tileManager.Start_Point)
        {
            return true;
        }


        if (downQuad.GetComponent<MeshRenderer>().materials[0].color
            != tileManager.TileList[currentDicePosition].GetComponent<MeshRenderer>().materials[0].color)
        {
            return false;
        } // 색깔이 다르면 움직일 수 없다.

        return true;
    }

}
