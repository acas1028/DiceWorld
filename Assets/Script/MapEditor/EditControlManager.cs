using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditControlManager : MonoBehaviour
{

    public TileManager tileManager;

    public GameObject Cursor;

    [SerializeField]
    GameObject selectedTile;

    [SerializeField]
    int selectedNumber;
    // Start is called before the first frame update
    void Start()
    {
        selectedNumber = 0;

        selectedTile = tileManager.TileList[selectedNumber];
    }

    // Update is called once per frame
    void Update()
    {
        selectedTile = tileManager.TileList[selectedNumber];

        selectedTile = tileManager.TileList[selectedNumber];
        Cursor.transform.position = selectedTile.transform.localPosition;

        SetCursorPosition();
        SetColor();

    }

    void SetCursorPosition()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedNumber < tileManager.GetMapScale_X()) return;
            selectedNumber -= tileManager.GetMapScale_X();

            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedNumber > tileManager.GetMapScale_X() * (tileManager.GetMapScale_Y() - 1) - 1) return;
            selectedNumber += tileManager.GetMapScale_X();

            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectedNumber % tileManager.GetMapScale_X() == tileManager.GetMapScale_X() - 1) return;
            selectedNumber += 1;

            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedNumber % tileManager.GetMapScale_X() == 0) return;
            selectedNumber -= 1;

            Cursor.transform.Translate(new Vector3(0.0f, 0.05f, 0.0f));
        }
    }

    void SetColor()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            selectedTile.GetComponent<TileStatus>().isTileFree = false;
            selectedTile.GetComponent<TileColorChange>().ColorChange(TileColor.red);

            tileManager.ResetFreeTile();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            selectedTile.GetComponent<TileStatus>().isTileFree = false;
            selectedTile.GetComponent<TileColorChange>().ColorChange(TileColor.green);

            tileManager.ResetFreeTile();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            selectedTile.GetComponent<TileStatus>().isTileFree = false;
            selectedTile.GetComponent<TileColorChange>().ColorChange(TileColor.blue);

            tileManager.ResetFreeTile();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            selectedTile.GetComponent<TileStatus>().isTileFree = false;
            selectedTile.GetComponent<TileColorChange>().ColorChange(TileColor.white);

            tileManager.ResetFreeTile();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            selectedTile.GetComponent<TileStatus>().isTileFree = false;
            selectedTile.GetComponent<TileColorChange>().ColorChange(TileColor.black);

            tileManager.ResetFreeTile();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            tileManager.Start_Point = selectedNumber;
            // 스타트

            tileManager.ResetFreeTile();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            tileManager.End_Point = selectedNumber;
            // 엔드
            selectedTile.GetComponent<TileStatus>().SettingFlag();
            tileManager.ResetFreeTile();
            tileManager.ResetEndTile();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            selectedTile.GetComponent<TileStatus>().isTileFree = !selectedTile.GetComponent<TileStatus>().isTileFree;

            tileManager.ResetFreeTile();
        }
    }

    public void ResetSelectedNumber()
    {
        selectedNumber = 0;
    }
}
