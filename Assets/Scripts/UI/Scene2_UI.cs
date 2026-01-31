using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene2_UI : MonoBehaviour
{
    public TextMeshProUGUI maskNums;
    public TextMeshProUGUI senergyNums;
    public Image icon;
    public TextMeshProUGUI useTips;
    public TextMeshProUGUI fadeTips;
    public TextMeshProUGUI fixTips;

    private void Start()
    {
        maskNums.text = WorldManager.Instance.limit.ToString();
        EventManager.AddListener(EventType.Scene2EnergyCollect, UpdateEnergyUI);
        EventManager.AddListener(EventType.Invert, UpdateMaskUI);
        EventManager.AddListener(EventType.UpdateSenergyUI, UpdateEnergyUI);
    }

    private void UpdateMaskUI()
    {
        maskNums.text = WorldManager.Instance.limit.ToString();
    }

    private void UpdateEnergyUI()
    {
        senergyNums.text = BuildManager.Instance.senery.ToString();
        icon.gameObject.SetActive(true);
        senergyNums.alpha = 1;
        useTips.alpha = 1;
        fadeTips.alpha = 1;
        fixTips.alpha = 1;
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(EventType.Scene2EnergyCollect, UpdateEnergyUI);
        EventManager.RemoveListener(EventType.Invert, UpdateMaskUI);
        EventManager.RemoveListener(EventType.UpdateSenergyUI, UpdateEnergyUI);
    }
}
