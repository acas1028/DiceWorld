using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIControl : MonoBehaviour
{
    public GameObject HelpUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        StartCoroutine(CStartButton());
    }

    IEnumerator CStartButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Stage_Select");
    }

    public void HelpButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);

        PlayerPrefs.DeleteAll();

        HelpUI.SetActive(true);
    }

    public void ExitButton()
    {
        StartCoroutine(CExitButton());
    }
    
    IEnumerator CExitButton()
    {
        SoundPlayer.Instance.ChangeAndPlay(2);

        yield return new WaitForSeconds(1.0f);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

}
