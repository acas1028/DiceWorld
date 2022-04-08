using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClearUIControl : MonoBehaviour
{
    public GameObject MoveCountText;
    public GameObject DeathCountText;


    public GameObject[] StageRankUI;
    public Sprite RankSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        int moveCount = GameObject.FindGameObjectWithTag("StackManager").GetComponent<StackManager>().MoveCount;
        MoveCountText.GetComponent<Text>().text = "ÀÌµ¿ È½¼ö : " + moveCount.ToString();

        int deathCount = GameObject.FindGameObjectWithTag("StackManager").GetComponent<StackManager>().DeathCount;
        DeathCountText.GetComponent<Text>().text = "»ç¸Á È½¼ö : " + deathCount.ToString();

        SetStageRank();
    }

    void SetStageRank()
    {
        int stageRank = 0;

        int moveRank = 0;
        int deathRank = 0;

        int moveStandard;
        GameObject dataManager = GameObject.FindWithTag("DataManager");

        moveStandard = dataManager.GetComponent<DataManager>().Rank_Moving;


        int moveCount = GameObject.FindGameObjectWithTag("StackManager").GetComponent<StackManager>().MoveCount;
        int deathCount = GameObject.FindGameObjectWithTag("StackManager").GetComponent<StackManager>().DeathCount;


        if (moveCount <= moveStandard) moveRank += 3;
        if (moveStandard < moveCount && moveCount <= moveStandard * 2) moveRank += 2;
        if (moveStandard * 2 < moveCount && moveCount <= moveStandard * 3) moveRank += 1;
        if (moveStandard * 3 < moveCount) moveRank += 0;

        if (deathCount == 0) deathRank += 3;
        if (deathCount == 1) deathRank += 2;
        if (deathCount == 2) deathRank += 1;
        if (deathCount > 2) deathRank += 0;

        stageRank = deathRank + moveRank;

        if(stageRank == 6)
        {
            for(int i = 0; i < 3; i++)
            {
                StageRankUI[i].GetComponent<Image>().sprite = RankSprite;
            }
        }

        if (3 <= stageRank && stageRank < 6)
        {
            for (int i = 0; i < 2; i++)
            {
                StageRankUI[i].GetComponent<Image>().sprite = RankSprite;
            }
        }

        if (1 <= stageRank && stageRank < 3)
        {
            for (int i = 0; i < 1; i++)
            {
                StageRankUI[i].GetComponent<Image>().sprite = RankSprite;
            }
        }

        if (PlayerPrefs.HasKey("UnlockNumber")) PlayerPrefs.SetInt("UnlockNumber", dataManager.GetComponent<DataManager>().MapNumber + 1);

        Destroy(dataManager);
    }

    public void ToMainMenu()
    {
        StartCoroutine(CButton());
    }

    IEnumerator CButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);


        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Stage_Select");
    }
}
