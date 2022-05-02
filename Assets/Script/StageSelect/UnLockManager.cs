using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockManager : MonoBehaviour
{
    public int unlocknumber;

    public int[] rank_Stage;
    public bool isunlocked;
    // Start is called before the first frame update
    void Start()
    {
        unlocknumber = 1;
        isunlocked = false;
        rank_Stage = new int[32];
        if (!PlayerPrefs.HasKey("UnlockNumber")) PlayerPrefs.SetInt("UnlockNumber", 1);
        else unlocknumber = PlayerPrefs.GetInt("UnlockNumber");


        for (int i = 0; i < 32; i++)
        {
            rank_Stage[i] = 0;
            string prefsString_StageRank = "Rank_Stage" + (i + 1).ToString();

            if (!PlayerPrefs.HasKey(prefsString_StageRank)) PlayerPrefs.SetInt(prefsString_StageRank, rank_Stage[i]);
            else rank_Stage[i] = PlayerPrefs.GetInt(prefsString_StageRank);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isunlocked == true) return;
        Unlock();

    }

    public void Unlock()
    {
        GameObject[] stageButton = GameObject.FindGameObjectsWithTag("StageButton");
        foreach (GameObject button in stageButton)
        {
            if (button.GetComponent<ButtonActivate>().buttonNumber <= unlocknumber)
                button.GetComponent<ButtonActivate>().isActivated = true;

            string prefsString_StageRank = "Rank_Stage" + button.GetComponent<ButtonActivate>().buttonNumber.ToString();

            if(PlayerPrefs.HasKey(prefsString_StageRank))
            {
                Debug.Log(prefsString_StageRank);
                Debug.Log(PlayerPrefs.GetInt(prefsString_StageRank));
                if(PlayerPrefs.GetInt(prefsString_StageRank) == 3)
                {
                    button.GetComponent<ButtonActivate>().isPerfect = true;
                }
            }
        }


        isunlocked = true;
    }
}
