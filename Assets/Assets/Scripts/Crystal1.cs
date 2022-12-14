using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCrystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.AddExp();
            Destroy(gameObject);
        }
    }
}
