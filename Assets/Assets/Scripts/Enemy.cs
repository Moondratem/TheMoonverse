using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Crystal crystalPrefab;
    [SerializeField] BloodCrystal BloodCrystal;
    [SerializeField] GoldCrystal GoldCrystal;
    [SerializeField] VoidBall Void;

    public bool isChasing = true;
    GameObject player;
    [SerializeField] public int enemyHP = 2;

    public int EnemyHP { get => enemyHP; set => enemyHP = value; }
    public float Speed { get => speed; set => speed = value; }

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        if (player == null)
        {
            return;
        }
        //direction = destination - source
        Vector3 destination = player.transform.position;
        Vector3 source = gameObject.transform.position;

        Vector3 direction = destination - source;
        if (!isChasing)
        {
            direction = Vector3.left;
        }

        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;
        //Change direction         
        transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.OnDamage();
        }
    }

    public bool IsDead()
    {
        if(this.enemyHP <= 0)
        {
            return true;
        }
        return false;
    }
    internal void Damage(int damage)
    {
        this.enemyHP -= damage;
        float randomVar = Random.Range(0, 360);
        if (this.IsDead())
        {
            StartCoroutine(DeathCoroutine());
            /*if(randomVar >= 300)
            {
                Instantiate(GoldCrystal, this.transform.position, Quaternion.identity);

            }
            else if(randomVar <= 90)
            {
                Instantiate(BloodCrystal, this.transform.position, Quaternion.identity);
            }
            else if(randomVar <= 5)
            {
                Instantiate(Void, this.transform.position, Quaternion.identity);
            }
            Instantiate(crystalPrefab, this.transform.position, Quaternion.identity);
            Destroy(gameObject);*/
        }
    }

    IEnumerator DeathCoroutine()
    {
        float randomVar = Random.Range(0, 360);
        if (randomVar >= 300)
        {
            Instantiate(GoldCrystal, this.transform.position, Quaternion.identity);

        }
        else if (randomVar <= 90)
        {
            Instantiate(BloodCrystal, this.transform.position, Quaternion.identity);
        }
        else if (randomVar <= 5)
        {
            Instantiate(Void, this.transform.position, Quaternion.identity);
        }
        Instantiate(crystalPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
