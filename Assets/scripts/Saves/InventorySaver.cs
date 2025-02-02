using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;


[Serializable]
public class InventorySaver : MonoBehaviour
{
    
    private List<KeyValuePair<string, int>> ItemSaveList = new List<KeyValuePair<string, int>>();
    private List<string> EquipSaveList = new List<string>();
    [SerializeField] private EquipInventorySlot[] equipSlots = new EquipInventorySlot[2]; 


    private void OnApplicationQuit()
    {
        SaveInventory();
        SaveEquip();
    }

    public void SaveInventory()
    {
        var slots = InventoryCore.Instance.slots;
        int rows = slots.GetLength(0);
        int cols = slots.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                InventorySlot slot = slots[i, j];
                if (slot != null && slot.item != null && slot.count > 0)
                {
                    ItemSaveList.Add(new KeyValuePair<string, int>(slot.item.itemName, slot.count));
                }
            }
        }

        string json = JsonConvert.SerializeObject(ItemSaveList, Formatting.Indented);
        string filePath = Path.Combine(Application.persistentDataPath, "saves.json");

        File.WriteAllText(filePath, json);
    }

    public void SaveEquip()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (equipSlots[i] != null && equipSlots[i].item != null)
            {
                EquipSaveList.Add(equipSlots[i].item.itemName);
            }
        }

        string json = JsonConvert.SerializeObject(EquipSaveList, Formatting.Indented);
        string filePath = Path.Combine(Application.persistentDataPath, "EquipSaves.json");

        File.WriteAllText(filePath, json);
    }
}
