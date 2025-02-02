using UnityEngine;

public class FightSystem : MonoBehaviour
{
    [SerializeField] private EnemySystem enemy;
    [SerializeField] private WeaponChoose weaponChoose;
    [SerializeField] private ItemData rifleAmmo, pistolAmmo;
    [SerializeField] private InventoryCore inventory;
    private InventorySlot AmmoSlot;
    public void HeroShot()
    {
        if(weaponChoose.Weapon == "Rifle")
        {
            if(AmmoSlot != null && AmmoSlot.count >= 3 && AmmoSlot.item.itemType == "Rifle_Ammo")
            {
                enemy.TakeDamage(9);
                enemy.TakeDamage(9);
                enemy.TakeDamage(9);
                AmmoSlot.AddItem(-3);
                EnemyShot();
            }
            else
            {
                AmmoSlot = inventory.CheckMinItem(rifleAmmo, 3);
                if(AmmoSlot != null && AmmoSlot.count >= 3)
                {
                    enemy.TakeDamage(9);
                    enemy.TakeDamage(9);
                    enemy.TakeDamage(9);
                    AmmoSlot.AddItem(-3);
                    EnemyShot();
                }
                else
                {
                    return;
                }
            }
        }

        if (weaponChoose.Weapon == "Pistol")
        {
            if (AmmoSlot != null && AmmoSlot.count >= 3 && AmmoSlot.item.itemType == "Pistol_Ammo")
            {
                enemy.TakeDamage(5);
                AmmoSlot.AddItem(-1);
                EnemyShot();
            }
            else
            {
                AmmoSlot = inventory.CheckMinItem(pistolAmmo, 3);
                if (AmmoSlot != null && AmmoSlot.count >= 3)
                {
                    enemy.TakeDamage(5);
                    AmmoSlot.AddItem(-1);
                    EnemyShot();
                }
                else
                {
                    return;
                }
            }
        }

    }

    public void EnemyShot()
    {
        HealthSystem.Instance.TakeHeadDamage(15);
        HealthSystem.Instance.TakeBodyDamage(15);
    }

}
