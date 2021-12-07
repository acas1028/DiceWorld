using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDice : MonoBehaviour
{
    public GameObject SuccessEffect;
    public GameObject FailEffect;
    public int speed = 300;
    bool isMoving = false;

    public bool isActivated = false;

    GameObject downQuad;
    TileManager tileManager;
    DiceGenerator diceGenerator;

    public int currentDicePosition;

    private void Start()
    {
        tileManager = GameObject.Find("TileManager").GetComponent<TileManager>();
        diceGenerator = GameObject.Find("DiceGenerator").GetComponent<DiceGenerator>();
        currentDicePosition = tileManager.Start_Point; // 차후 변경 있을 수 있음.
    }
    void Update()
    {

        downQuad = GetComponent<DiceQuad>().DownQuad;

        if (isActivated) return;

        if (isMoving)
        {
            return;
        }

        if(Input.GetKey(KeyCode.RightArrow)) 
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
        Vector3 rotationAxis = Vector3.Cross(Vector3.up,direction);



        while(remainingAngle > 0)
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
        }
        else
        {
            GameObject effect = GameObject.Instantiate(FailEffect);
            effect.transform.position = transform.position;
            Destroy(effect, 1.0f);
            diceGenerator.CResetDice();
            Destroy(gameObject);
          
        }
        
        isMoving = false;
    }

    bool CheckMove()
    {
        Debug.Log(downQuad.GetComponent<MeshRenderer>().materials[0].color);
        Debug.Log(tileManager.TileList[currentDicePosition].GetComponent<MeshRenderer>().materials[0].color);

        if(currentDicePosition == tileManager.End_Point)
        {
            StageControl.Instance.ActiveUI();
        }
        if(currentDicePosition == tileManager.End_Point || currentDicePosition == tileManager.Start_Point)
        {
            return true;
        }

        if(downQuad.GetComponent<MeshRenderer>().materials[0].color 
            != tileManager.TileList[currentDicePosition].GetComponent<MeshRenderer>().materials[0].color)
        {
            return false;
        } // 색깔이 다르면 움직일 수 없다.

        return true;
    }

}
