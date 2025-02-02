using UnityEngine;

public class InventoryCore : MonoBehaviour
{
    [SerializeField] private InventoryCreator Creator;
    [SerializeField] private InventoryCFG InventoryConfig;
    public InventorySlot[,] slots;

    public static InventoryCore Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        slots = Creator.GenerateInventory(InventoryConfig);
        
    }


    public void AddItem(ItemData item, int amount)
    {
        for (int y = 0; y < InventoryConfig.Row; y++)
        {
            for (int x = 0; x < InventoryConfig.Columns; x++)
            {
                var slot = slots[x, y];

                if (slot.item == item && slot.count < item.maxStack)
                {
                    int toAdd = Mathf.Min(item.maxStack - slot.count, amount);
                    slot.AddItem(toAdd);
                    amount -= toAdd;

                    if (amount <= 0)
                        return;
                }
            }
        }

        for (int y = 0; y < InventoryConfig.Row; y++)
        {
            for (int x = 0; x < InventoryConfig.Columns; x++)
            {
                var slot = slots[x, y];

                if (slot.item == null)
                {
                    int toSet = Mathf.Min(amount, item.maxStack);
                    slot.SetItem(item, toSet);
                    amount -= toSet;

                    if (amount <= 0)
                        return;
                }
            }
        }
    }

    public InventorySlot CheckItem(ItemData item)
    {
        for (int y = 0; y < InventoryConfig.Row; y++)
        {
            for (int x = 0; x < InventoryConfig.Columns; x++)
            {
                var slot = slots[x, y];

                if (slot.item == item)
                    return slot;
            }
        }
        return null;
    }

    public InventorySlot CheckMinItem(ItemData item, int minCount)
    {
        for (int y = 0; y < InventoryConfig.Row; y++)
        {
            for (int x = 0; x < InventoryConfig.Columns; x++)
            {
                var slot = slots[x, y];

                if (slot.item == item && slot.count > minCount)
                    return slot;
            }
        }
        return null;
    }



    public InventorySlot GetSlot(int x, int y)
    {
        if (x < 0 || x >= InventoryConfig.Columns || y < 0 || y >= InventoryConfig.Row) return null;
        return slots[x, y];
    }
}
