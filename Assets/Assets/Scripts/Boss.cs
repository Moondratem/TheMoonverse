using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Windows;

public class Boss : MonoBehaviour
{
    [SerializeField] Enemy BossMan;
    [SerializeField] GameObject Player;
    Animator animator;
    public bool Chassing = true;
    public void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void Update()
    {
        int distance = (int)(Player.transform.position - BossMan.transform.position).magnitude;
        if(BossMan.EnemyHP <= 10)
        {
            BossMan.Speed = 2;
        }
        if(distance >= 50)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("InRange", false);
            Chassing = false;
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("InRange", true);
            Chassing= true;
        }
    }

    
}
