using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : BaseWeapon
{
    public float pierce_Amount;
    public float pierce;
    [SerializeField] Player player;
    private void Start()
    {
        Destroy(gameObject, 3);
        pierce_Amount = level;
    }

    private void Update()
    {
        transform.position += transform.right * 5 * Time.deltaTime;            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(2);
            pierce++;
            if(pierce >= pierce_Amount)
            {
                Destroy(gameObject);
            }
        }
    }
}
