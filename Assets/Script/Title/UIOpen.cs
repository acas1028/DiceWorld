using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpen : MonoBehaviour
{
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUI()
    {
        SoundPlayer.Instance.ChangeAndPlay(0);
        UI.SetActive(true);
    }
}
