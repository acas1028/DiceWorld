using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClose : MonoBehaviour
{
    public GameObject CloseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIClosing()
    {
        SoundPlayer.Instance.ChangeAndPlay(1);
        CloseUI.SetActive(false);
    }
}
