using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPBar : MonoBehaviour
{    
    [SerializeField] Player player;
    [SerializeField] GameObject foreground;

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        transform.position = player.transform.position + new Vector3(0, 0.75f, 0);

        // ratio between 0 and 1
        float hpRatio = (float)player.playerHP / player.playerMaxHP;
        foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
    }
}
