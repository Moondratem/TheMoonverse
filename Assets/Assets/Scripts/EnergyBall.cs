using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : BaseWeapon
{
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.Damage(3);
        }
    }
}
