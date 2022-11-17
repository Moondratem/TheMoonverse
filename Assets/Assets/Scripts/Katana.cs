using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    [SerializeField] Player player;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(KatanaCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(level);
        }

        //Destroy(collision.gameObject);
    }

    IEnumerator KatanaCoroutine()
    {
        while (true)
        {
            transform.localScale = Vector3.one * level;
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(2f);
        }
    }
}
