using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public CharacterHealthData healthData; 
   [SerializeField] private float currentHealth;
    public GameObject[] healthIcons;
    public bool isPlayer;

    void Start()
    {
        currentHealth = healthData.maxHealth;
        UpdateHealthDisplay();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (isPlayer)
        {
            UpdateHealthDisplay();
        }
    }

    private void UpdateHealthDisplay()
    {
        if (isPlayer)
        {
            int healthCount = Mathf.FloorToInt(currentHealth) / Mathf.FloorToInt(healthData.maxHealth / healthIcons.Length);
            for (int i = 0; i < healthIcons.Length; i++)
            {
                healthIcons[i].SetActive(i < healthCount);
            }
        }
    }

    private void Die()
    {
        if (isPlayer)
        {
            SceneManager.LoadScene("GameOverScene");
            //Debug.Log($"{gameObject.name} has died!");
        }
        else
        {
            CheckVictoryCondition();
        }
    }
    private void CheckVictoryCondition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null && playerHealth.currentHealth > 0)
            {
                SceneManager.LoadScene("VictoryScene");
                //Debug.Log($"{gameObject.name} has died!");
            }
        }

    }
}