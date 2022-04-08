using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageUIController : MonoBehaviour
{
    public GameObject UnlockManager;
    public GameObject NextButton;
    public GameObject PreviousButton;
    public GameObject Stage1Object;
    public GameObject Stage2Object;
    public GameObject Stage3Object;
    public GameObject Stage4Object;
    public Text Title;

    public int stageNumber;
    // Start is called before the first frame update
    void Start()
    {
        stageNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (stageNumber == 1 && PreviousButton.activeSelf) PreviousButton.SetActive(false);
        if (stageNumber == 4 && NextButton.activeSelf) NextButton.SetActive(false);

        Title.text = "Stage " + stageNumber.ToString();
    }

    public void PushNextButton()
    {
        PreviousButton.SetActive(true);
        stageNumber++;

        Stage1Object.SetActive(false);
        Stage2Object.SetActive(false);
        Stage3Object.SetActive(false);
        Stage4Object.SetActive(false);

        UnlockManager.GetComponent<UnLockManager>().isunlocked = false;
        ActivatedStageObject(stageNumber);
    }

    public void PushPreviousButton()
    {
        NextButton.SetActive(true);
        stageNumber--;

        Stage1Object.SetActive(false);
        Stage2Object.SetActive(false);
        Stage3Object.SetActive(false);
        Stage4Object.SetActive(false);

        UnlockManager.GetComponent<UnLockManager>().isunlocked = false;
        ActivatedStageObject(stageNumber);
    }

    public void ActivatedStageObject(int number)
    {
        switch(number)
        {
            case 1:
                Stage1Object.SetActive(true);
                break;
            case 2:
                Stage2Object.SetActive(true);
                break;
            case 3:
                Stage3Object.SetActive(true);
                break;
            case 4:
                Stage4Object.SetActive(true);
                break;
        }
    }

    public void PushHomeButton()
    {

        StartCoroutine(CHomeButton());
    }

    IEnumerator CHomeButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Title");
    }
}
