using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    public bool isBlack = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        UpdateAppearance();
        EventManager.AddListener(EventType.Invert, Invert);
    }
    

    public void Invert()
    {
        isBlack = !isBlack;
        UpdateAppearance();
    }

    void UpdateAppearance()
    {
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
    }
}
