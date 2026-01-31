using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    public bool isBlack = true;
    public bool isFixed = false;

    public Color startColor;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        collider2d = GetComponent<BoxCollider2D>();
        UpdateAppearance();
        EventManager.AddListener(EventType.Invert, Invert);
        EventManager.AddListener(EventType.Fixed, Fixed);
        EventManager.AddListener(EventType.CancelFixed,CancelFixed);
    }

    private void CancelFixed()
    {
        isFixed = false;
        spriteRenderer.color = startColor;
    }

    private void Fixed()
    {
        if (isFixed)
        {
            collider2d.enabled = true;
        }
            
    }


    public void Invert()
    {
        isBlack = !isBlack;
        UpdateAppearance();
    }

    void UpdateAppearance()
    {
        if(isFixed) return;
        if (isBlack)
        {
            spriteRenderer.color = Color.black;
            collider2d.enabled = true;
        }
        else
        {
            spriteRenderer.color = Color.white;
            collider2d.enabled = false;
        }
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(EventType.Invert, Invert);
        EventManager.RemoveListener(EventType.Fixed, Fixed);
        EventManager.RemoveListener(EventType.CancelFixed, CancelFixed);
    }
}
