using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public int staminaLevel = 10;
    public int maxStamina;
    public int currentStamina;

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    AnimatorHandler animatorHandler;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
    }

    float lastTime = 1.0f;
    float counter = 0;
    private void Update()
    {
        counter += Time.deltaTime;
        if(counter>lastTime)
        {
            if (currentHealth < maxHealth)
                GainHealth(1);
            lastTime = 1;
            counter = 0;
        }
    }

    // Start is called before the first frame update
    void Start() 
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        maxStamina = SetMaxStamina();
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    private int SetMaxStamina()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.SetCurrentHealth(currentHealth);

        animatorHandler.PlayTargetAnimation("Hit Reaction", true);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Death", true);
            //Handle Player Death
            MenuManager.instance.ShowDeathUI();
        }
    }

    public void GainHealth(int health)
    {
        currentHealth = currentHealth + health;
        healthBar.SetCurrentHealth(currentHealth);

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeStaminaDamage(int damage)
    {
        currentStamina = currentStamina - damage;
        staminaBar.SetCurrentStamina(currentStamina);
        lastTime = 10;
        counter = 0;
    }
}