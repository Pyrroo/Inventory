using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/EquipItem")]
public class EquipItemData : ItemData
{
    public string BodyPart; // Куда одевать
    public int armor;       // Сколько защиты
}
