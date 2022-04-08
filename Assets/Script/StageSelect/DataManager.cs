using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public string MapName;
    public int MapNumber;

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

    IEnumerator CStartButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Stage_Sample");
    }
}
