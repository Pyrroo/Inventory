using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;      // Название предмета
    public Sprite icon;          // Иконка предмета
    public string itemType;      // Тип предмета (оружие, ресурс и т. д.)
    public int maxStack;         // Максимальное количество в одной ячейке
    public float mass;           // Масса предмета
}
