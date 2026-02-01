using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void OnResetButtonClick()
    {
        EventManager.Broadcast(EventType.ResetData);
    }
}
