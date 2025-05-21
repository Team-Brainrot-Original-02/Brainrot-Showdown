using UnityEngine;
using UnityEngine.UI;

//da attaccare al giocatore e all'npc nemico
//gestisce la logica della salute di entrambi

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth;   
    public Slider healthBar;      

    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthBar();      
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;  
        if (currentHealth <= 0)
        {
            currentHealth = 0;    
            Die();              
        }
        UpdateHealthBar();  
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        // Handle death (e.g., disable character movement, trigger animation, etc.)
    }
}