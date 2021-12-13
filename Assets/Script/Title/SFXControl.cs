using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXControl : MonoBehaviour
{
    public bool isBGM;
    public bool isSound;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBGM)
            slider.value = SFXManager.Instance.BGMValue;

        if (isSound)
            slider.value = SFXManager.Instance.SoundValue;
    }

    public void ChangeValue()
    {
        if (isBGM)
            SFXManager.Instance.BGMValue = slider.value;

        if (isSound)
            SFXManager.Instance.SoundValue = slider.value;
    }
}
