using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : Enemy
{
    enum GiantState{ Idle, Chasing, Attack};
    private Animator animator;
    GiantState giantState = GiantState.Idle;
    float waitTimer = 2f;
    GameObject player;
    [SerializeField] GameObject knifePrefab;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    protected override void Update()
    {
        
        switch (giantState)
        {
            case GiantState.Idle:
                waitTimer -= Time.deltaTime;
                if(waitTimer <= 0)
                {
                    giantState = GiantState.Chasing;
                }
                break;
            case GiantState.Chasing:
                float distance = Vector3.Distance(transform.position, player.transform.position);
                base.Update();
                if (distance > 5f)
                {
                    animator.SetBool("IsWalking", true);
                }
                else
                {
                    animator.SetBool("IsWalking", false);
                    giantState = GiantState.Attack;
                }
                break;
            case GiantState.Attack:
                
                animator.SetTrigger("Attack");
                giantState = GiantState.Idle;
                waitTimer = 3f;
                break;
        }
    }
    public void SpawnKnife(int number)
    {
        Vector3 delta = player.transform.position - transform.position;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle );
        Instantiate(knifePrefab, transform.position, rotation);
    }
}
