using UnityEngine;

public class WeaponChoose : MonoBehaviour
{
    public string Weapon;

    public void ChooseRifle()
    {
        Weapon = "Rifle";
    }

    public void ChoosePistol()
    {
        Weapon = "Pistol";
    }
    
}
