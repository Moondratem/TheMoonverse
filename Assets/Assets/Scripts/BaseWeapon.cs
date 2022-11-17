using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] GameObject LevelMenu;
    protected int level = 0;

    public void LevelUp()
    {
        if(++level == 1)
        {
            gameObject.SetActive(true);
        }
        Thread.Sleep(500);
        Time.timeScale = 1;
        LevelMenu.SetActive(false);
    }
}
