using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int LevelIndex = 0;
    private Text _text;
    
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        _text.text = $"{LevelIndex + 1}";
    }

    void Update()
    {
        
    }
}
