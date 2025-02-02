using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GreenButtonText, itemName;
    [SerializeField] private Image ItemImage;
    [SerializeField] private ItemCreator itemCreator;

    [SerializeField] private EquipInventorySlot[] EquipSlots;

    private InventorySlot slot;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void OpenPopUp(InventorySlot slot)
    {
        gameObject.SetActive(true);
        this.slot = slot;
        ItemImage.sprite = this.slot.item.icon;
        itemName.text = this.slot.item.name;

        switch (slot.item.itemType)
        {
            case "Rifle_Ammo":
                GreenButtonText.text = " упить";
                break;

            case "Pistol_Ammo":
                GreenButtonText.text = " упить";
                break;

            case "Heal":
                GreenButtonText.text = "Ћечитьс€";
                break;

            case "Equip":
                GreenButtonText.text = "Ёкипировать";
                break;
        }


        
           
    }

    public void GreenButton()
    {



        switch (slot.item.itemType)
        {
            case "Rifle_Ammo":                
                itemCreator.CreateRifleAmmo(slot.item.maxStack - slot.count);                    
                break;

            case "Pistol_Ammo":
                itemCreator.CreatePistolAmmo(slot.item.maxStack - slot.count);
                break;

            case "Heal":
                HealthSystem.Instance.Heal(50);
                slot.AddItem(-1);
                break;
        }

        if (slot.item is EquipItemData)
        {
            EquipItemData equipItem = slot.item as EquipItemData;
            for(int i = 0; i < EquipSlots.Length; i++)
            {
                if(equipItem.BodyPart == EquipSlots[i].BodyPart)
                {
                    if(EquipSlots[i].item == null)
                    {
                        EquipSlots[i].SetItem(equipItem);
                        slot.DoEmpty();
                    }
                    else
                    {
                        InventorySlot temp = slot.gameObject.AddComponent<InventorySlot>();
                        temp.CopySlot(slot);
                        slot.ReSetSlot(EquipSlots[i]);
                        EquipSlots[i].ReSetItem(equipItem);
                        Destroy(temp);
                    }
                }
            }


        }

        gameObject.SetActive(false);
    }



    public void DeleteItem()
    {
        slot.DoEmpty();
        gameObject.SetActive(false);
    }
}
