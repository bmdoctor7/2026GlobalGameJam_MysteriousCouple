using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene1_UI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI num;
    public TextMeshProUGUI text2;
    
    void Start()
    {
        num.text = WorldManager.Instance.limit.ToString();
        EventManager.AddListener(EventType.Invert, UpdateText);
        EventManager.AddListener(EventType.NumlimitsTips, ResetText);
    }

    private void ResetText()
    {
        num.text = WorldManager.Instance.limit.ToString();
        num.alpha = 1f;
        text2.alpha = 1f;
    }

    private void UpdateText()
    {
        num.text = WorldManager.Instance.limit.ToString();
        text.alpha = 1f;
        if(text1.color == Color.black)
            text1.color = Color.white;
        else
            text1.color = Color.black;
        
        // if(text2.color == Color.black)
        //     text2.color = Color.white;
        // else
        //     text2.color = Color.black;
        
        if(text.color == Color.black)
            text.color = Color.white;
        else
            text.color = Color.black;
        
        // if(num.color == Color.black)
        //     num.color = Color.white;
        // else
        //     num.color = Color.black;
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(EventType.Invert, UpdateText);
        EventManager.RemoveListener(EventType.NumlimitsTips, ResetText);
    }
}
