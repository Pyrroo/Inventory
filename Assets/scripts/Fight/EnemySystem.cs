using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [SerializeField] private HealthBars healthBar;
    [SerializeField] private ItemCreator creator;
    private int Health;
    private int MaxHealth = 100;


    private void Start()
    {
        SetMaxHealth();
    }

    public void SetHealth(int value)
    {
        Health = value;
        healthBar.SetEnemySlider(Health);
    }

    public void SetMaxHealth()
    {
        Health = MaxHealth;
        healthBar.SetEnemySlider(Health);
    }
    public int GetHealth()
    {
        return Health;
    }

    public void TakeDamage(int Damage)
    {
        if (Damage >= Health)
        {
            creator.CreateRandomItem();
            SetMaxHealth();
        }
        else
        {
            Health -= Damage;
            healthBar.SetEnemySlider(Health);
        }
    }
}

