using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeControl : MonoBehaviour
{
    public Vector3 startPos;
    void Start()
    {
       //startPos = transform.position;
        EventManager.AddListener(EventType.ResetData, ResetPosition);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(EventType.ResetData, ResetPosition);
    }

    private void ResetPosition()
    {
        transform.position = startPos;
    }
}
