using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] GameObject LevelMenu;
    [SerializeField] BaseWeapon[] weapons;
    
    SpriteRenderer spriteRenderer;
    Animator animator;
    Material material;
    internal int playerMaxHP = 10;
    internal int playerHP;
    bool isInvincible;

    internal int currentExp;
    internal int expToLevel = 5;
    internal int currentLevel;
    internal int playerpower = 1;

    internal Action<int, int> OnExpGained;
    public ParticleSystem ps;
    public float GetHPRatio()
    {
        return (float)playerHP / playerMaxHP;
    }
    private void Start()
    {
        weapons[0].LevelUp();

        playerHP = playerMaxHP;    

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ps = GetComponent<ParticleSystem>();
        material = GetComponent<SpriteRenderer>().material;
    }

    internal void AddExp()
    {
        currentExp++;

        if(currentExp >= expToLevel)
        {
            currentExp -= expToLevel;
            currentLevel++;
            expToLevel += 5;

            

            Time.timeScale = 0;
            LevelMenu.SetActive(true);
        }

        OnExpGained(currentExp, expToLevel);
    }
    internal void Big_Heal()
    {
        if (this.playerHP < this.playerMaxHP)
        {
            this.playerHP += this.playerMaxHP / 2;
            StartCoroutine(HealCoroutine());
        }
    }
    internal void Heal()
    {
        if(this.playerHP < this.playerMaxHP)
        {
            this.playerHP += this.playerMaxHP/4;
            StartCoroutine(HealCoroutine());
        }
    }
    internal void OnDamage()
    {                
        if(!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());            
                        
            if (--playerHP <= 0)
            {
                //increase death count
                TitleManager.saveData.deathCount++;                
                SceneManager.LoadScene("Title");
            }
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;

        isInvincible = false;
    }
    IEnumerator HealCoroutine()
    {
        material.SetFloat("_Heal", 0.33f);
        yield return new WaitForSeconds(0.5f);
        material.SetFloat("_Heal", 0f);
    }


    void Update()
    {        
        if(playerHP <= playerMaxHP/2)
        {
            ps.Play();
            speed = 3.5f;
        }
        else
        {
            ps.Pause();
            speed = 2.5f;
        }
        //Move
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;

        //Manual Attack        
        //weapon.SetActive(Input.GetKey(KeyCode.Z););

        //Flip Sprite
        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX > 0 ? -1f : 1, 1, 1);
        }
        
        //Running animation
        animator.SetBool("IsRunning", inputX != 0 || inputY != 0);
    }

    
}
