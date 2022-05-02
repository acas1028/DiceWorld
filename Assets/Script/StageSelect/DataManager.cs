using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public string MapName;
    public int MapNumber;
    public bool isDoubleDiceStage;

    public int Rank_Moving;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingMapName(int number)
    {
        MapName = "Stage_" + number.ToString();
        MapNumber = number;

        StartCoroutine(CStartButton());
    }

    public void SettingIsDoubleDiceStage(bool isDouble)
    {
        isDoubleDiceStage = isDouble;
    }

    IEnumerator CStartButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);

        yield return new WaitForSeconds(1.0f);

        if (isDoubleDiceStage)
            SceneManager.LoadScene("Stage_DoubleDice");
        else
            SceneManager.LoadScene("Stage_Sample");
    }
}
