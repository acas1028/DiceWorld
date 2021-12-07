using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageControl : MonoBehaviour
{
    private static StageControl instance = null;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }
    }

    public static StageControl Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    public GameObject ClearUI;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveUI()
    {
        StartCoroutine(CActiveUI());
    }

    IEnumerator CActiveUI()
    {
        yield return new WaitForSeconds(0.5f);

        ClearUI.SetActive(true);
    }
}
