using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{    
    [SerializeField] Player player;
    [SerializeField] Image foreground;

    private void Start()
    {
        player.OnExpGained += OnExpGained;
        OnExpGained(0, 1);
    }

    private void OnExpGained(int currentExp, int expToLevel)
    {
        float expRatio = (float)currentExp / expToLevel;
        foreground.transform.localScale = new Vector3(expRatio, 1, 1);
    }

}
