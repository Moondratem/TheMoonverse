using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] Player player;
    private void Start()
    {
        Destroy(gameObject, 5);
        
    }

    private void Update()
    {
        transform.position += transform.right * 5 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (player)
        {
            player.OnDamage();
            Destroy(gameObject);
        }
    }
}
