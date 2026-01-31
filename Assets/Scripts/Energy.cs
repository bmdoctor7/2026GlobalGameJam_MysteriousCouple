using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int type; // 1代表Square，2代表Circle

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Black"))
        {
            Destroy(gameObject);
            EventManager.Broadcast(EventType.Scene2EnergyCollect);
        }
        
    }
}
