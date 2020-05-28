using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHp : MonoBehaviour
{
    public static int  maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;
    public int regenRate=60;
    public int regen = 0;
 
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (currentHealth <= 0)
        {
            EndGame();
        }
       
    }

    private void FixedUpdate()
    {
        
        regenRate--;
        if (regenRate <=0&& currentHealth<maxHealth)
        {
            currentHealth += regen;
            regenRate = 60;
            healthBar.SetHealth(currentHealth);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(200);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
