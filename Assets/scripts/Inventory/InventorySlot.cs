using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private ItemCount_UI UI;
    public ItemData item;           
    public int count;
    public InventorySlot CreateSlot(ItemData item, int count )
    {
        this.item = item;
        this.count = count;
        UI.UpdateText(this.count);
        return this;
    }
    public void SetItem(ItemData item, int count)
    {
        
        this.item = item;
        this.count = count;
        UI.UpdateText(this.count);
        icon.sprite = item.icon;
    }
    public void AddItem(int count)
    {
        if(count < 0 && this.count == 1)
        {
            DoEmpty();
        }
        else
        {
            this.count += count;
            UI.UpdateText(this.count);
        }
        
        
    }


    public void ReSetSlot(InventorySlot slot)
    {
        if(slot.item != null)
        {
            item = slot.item;
            count = slot.count;
            UI.UpdateText(count);
            icon.sprite = slot.item.icon;
        }
    }
    public void ReSetSlot(EquipInventorySlot slot)
    {
        if (slot.item != null)
        {
            item = slot.item;
            count = 1;
            UI.UpdateText(count);
            icon.sprite = slot.item.icon;
        }
    }
    public void CopySlot(InventorySlot slot)
    {
        item = slot.item;
        count = slot.count;
    }
    public void DoEmpty()
    {
        item = null;
        count = 0;
        UI.UpdateText(this.count);
        icon.sprite = null;
    }

}
