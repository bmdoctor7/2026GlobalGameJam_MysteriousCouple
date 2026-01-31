using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldManager : SingletonMonoBase<WorldManager>
{
    private WorldManager(){}

    private void Start()
    {
        // 初始化时设置到第一关
        SetLevel(0);
        DontDestroyOnLoad(gameObject);
    }

    public int currentLevel = 0;

    // 每一关对应一个 limit，在 Inspector 里配置
    public List<int> levelLimits = new List<int>();

    // 当前关卡的 limit（由 SetLevel 自动更新）
    public int limit = 2;

    public ArrayList levels = new ArrayList();

    // 设置当前关卡，并根据关卡更新 limit
    public void SetLevel(int levelIndex)
    {
        // 防止越界
        currentLevel = Mathf.Clamp(levelIndex, 0, Mathf.Max(levelLimits.Count - 1, 0));

        if (levelLimits.Count > 0)
        {
            limit = levelLimits[currentLevel];
        }
        else
        {
            // 如果没配置，使用一个默认值
            limit = 2;
        }

        // TODO: 在这里加载关卡数据、刷新场景等
        Debug.Log($"切换到关卡 {currentLevel}，limit = {limit}");
    }

    
}
