using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUIControl : MonoBehaviour
{
    public int currentPage;

    public List<Sprite> imageList;
    public List<string> helpTextList;

    public GameObject LeftButton;
    public GameObject RightButton;

    public Text helpText;
    public Image helpImage;


    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!LeftButton.activeSelf)
            LeftButton.SetActive(true);
        if(!RightButton.activeSelf)
            RightButton.SetActive(true);

        if (currentPage == 0)
            LeftButton.SetActive(false);
        if (currentPage == imageList.Count - 1)
            RightButton.SetActive(false);

        helpImage.sprite = imageList[currentPage];
        helpText.text = helpTextList[currentPage];
    }

    public void CloseHelp()
    {
        gameObject.SetActive(false);
    }

    public void LeftButtonClick()
    {
        if (currentPage < 0) return;
        currentPage--;
    }

    public void RightButtonClick()
    {
        if (currentPage >= imageList.Count) return;
        currentPage++;
    }
}
