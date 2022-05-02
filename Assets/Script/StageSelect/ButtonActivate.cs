using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivate : MonoBehaviour
{
    public int buttonNumber;

    public bool isActivated;
    public bool isPerfect;

    public GameObject LockImage;
    public GameObject PerfectImage;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        isPerfect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LockImage.activeSelf && isActivated) LockImage.SetActive(false);

        if (!PerfectImage.activeSelf && isPerfect) PerfectImage.SetActive(true);
    }
}
