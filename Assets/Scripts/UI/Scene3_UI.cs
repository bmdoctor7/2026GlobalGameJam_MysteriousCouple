using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Scene3_UI : MonoBehaviour
{
    public TextMeshProUGUI maskNums;
    public TextMeshProUGUI cenergyNums;
    public Image icon;
    public TextMeshProUGUI useTips;
    public TextMeshProUGUI fadeTips;

    private void Start()
    {
        maskNums.text = WorldManager.Instance.limit.ToString();
        EventManager.AddListener(EventType.Scene2EnergyCollect, UpdateEnergyUI);
        EventManager.AddListener(EventType.Invert, UpdateMaskUI);
        EventManager.AddListener(EventType.UpdateSenergyUI, UpdateEnergyUI);
        EventManager.AddListener(EventType.Fixed, UpdateEnergyUI);
        EventManager.AddListener(EventType.CancelFixed,UpdateEnergyUI);
    }

    private void UpdateMaskUI()
    {
        maskNums.text = WorldManager.Instance.limit.ToString();
    }

    private void UpdateEnergyUI()
    {
        cenergyNums.text = BuildManager.Instance.cenergy.ToString();
        icon.gameObject.SetActive(true);
        cenergyNums.alpha = 1;
        useTips.alpha = 1;
        fadeTips.alpha = 1;
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(EventType.Scene2EnergyCollect, UpdateEnergyUI);
        EventManager.RemoveListener(EventType.Invert, UpdateMaskUI);
        EventManager.RemoveListener(EventType.UpdateSenergyUI, UpdateEnergyUI);
        EventManager.RemoveListener(EventType.Fixed, UpdateEnergyUI);
        EventManager.RemoveListener(EventType.CancelFixed,UpdateEnergyUI);
    }
}
