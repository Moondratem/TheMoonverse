using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimer : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject BossMan;
    GameObject player;
    [SerializeField] int enemyHP = 2;
    Animator animator;
    public bool Chassing = true;
    public int EnemyHP { get => enemyHP; set => enemyHP = value; }
    public float Speed { get => speed; set => speed = value; }

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (player == null)
        {
            return;
        }
        //direction = destination - source
        Vector3 destination = player.transform.position;
        Vector3 source = gameObject.transform.position;

        Vector3 direction = destination - source;

        direction.Normalize();
        if(Chassing == true)
        {
            transform.position += direction * Time.deltaTime * speed;

        }
        //Change direction         
        transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);

        int distance = (int)(player.transform.position - BossMan.transform.position).magnitude;
        if (EnemyHP <= 10)
        {
            Speed = 2;
        }
        if (distance >= 50)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("InRange", false);
            Chassing = false;
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("InRange", true);
            Chassing = true;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.OnDamage();
        }
    }

    internal void Damage(int damage)
    {
        float randomVar = Random.Range(0, 360);
        this.enemyHP -= damage;
        if (this.enemyHP <= 0)
        {
            
            Destroy(gameObject);
        }
    }
}
