using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player)
        {
            GameObject[] crystals = GameObject.FindGameObjectsWithTag(tag: "Crystal");
            if(crystals.Length > 0)
            {
                foreach(GameObject crystal in crystals)
                {
                    Crystal cryst = crystal.GetComponent<Crystal>();
                    cryst.MagnetToPlayer();
                    
                }
                
            }
            crystals = null;
            Destroy(gameObject);
        }
    }
}
