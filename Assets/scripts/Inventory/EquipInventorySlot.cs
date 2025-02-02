using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EquipInventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    public string BodyPart;
    public EquipItemData item;
    public int Armor;

    private void Start()
    {
        Armor = 0;
    }

    public void SetItem(EquipItemData item)
    {
        if(item.BodyPart == BodyPart)
        {
            this.item = item;
            Armor = item.armor;
            icon.sprite = item.icon;
        }
    }
    public void ReSetItem(EquipItemData item)
    {
        if (item.BodyPart == BodyPart)
        {
            this.item = item;
            Armor = item.armor;
            icon.sprite = item.icon;
        }
    }


}
