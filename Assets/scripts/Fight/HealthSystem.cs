using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public static HealthSystem Instance;
    [SerializeField] private HealthBars healthBar;
    [SerializeField] private EquipInventorySlot Head, body;
    [SerializeField] private GameObject DeadCanvas;

    private int Health;
    private int MaxHealth = 100;

    private void Start()
    {
        DeadCanvas.SetActive(false);
        if (Instance == null)
            Instance = this;
        SetMaxHealth();
    }
    public void SetHealth(int value)
    {
        Health = value;
        healthBar.SetHeroSlider(Health);
    }

    public void SetMaxHealth()
    {
        Health = MaxHealth;
        healthBar.SetHeroSlider(Health);
    }
    public int GetHealth()
    {
        return Health;
    }
    public void Heal(int Heal)
    {
        int toHeal = Mathf.Min(MaxHealth - Health, Heal);

        Health += toHeal;
        healthBar.SetHeroSlider(Health);
    }

    public void TakeHeadDamage(int Damage)
    {
        Damage -= Head.Armor;

        if (Damage >= Health)
        {
            Debug.Log("Cмерть");
        }
        else
        {
            Health -= Damage;
            healthBar.SetHeroSlider(Health);
        }
    }
    public void TakeBodyDamage(int Damage)
    {
        Damage -= body.Armor;

        if (Damage >= Health)
        {
            DeadCanvas.SetActive(true);
        }
        else
        {
            Health -= Damage;
            healthBar.SetHeroSlider(Health);
        }
    }
}
