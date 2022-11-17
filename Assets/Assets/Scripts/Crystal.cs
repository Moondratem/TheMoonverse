using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]  float speed = 1;
    [SerializeField]  Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.AddExp();
            Destroy(gameObject);
        }
    }

    public void MagnetToPlayer()
    {
        player = GameObject.FindGameObjectWithTag(tag: "Player").GetComponent<Player>();
        if(player)
        {
            StartCoroutine(MoveToPlayer(player));
        }
    }

    IEnumerator MoveToPlayer(Player player)
    {
        while (player)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = gameObject.transform.position;
            Vector3 direction = destination - source;
            direction.Normalize();
            transform.position += speed * Time.deltaTime * direction;
            yield return null;
        }
    }
}
