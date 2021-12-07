using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLoadMapName : MonoBehaviour
{
    public TileManager tileManager;
    public InputField m_InputField;
    
    // Start is called before the first frame update
    void Start()
    {
        m_InputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMapNameChange()
    {
        tileManager.MapName = m_InputField.text;
    }
}
