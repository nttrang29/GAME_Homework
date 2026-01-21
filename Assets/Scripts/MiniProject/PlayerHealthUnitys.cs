using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthUnitys : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public UnityEvent<float, float> OnHealthChanged; 
    public UnityEvent OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        OnHealthChanged.Invoke(currentHealth, maxHealth); 

        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}