using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
public class EquipLoader : MonoBehaviour
{
    [SerializeField] private EquipInventorySlot[] equipSlots = new EquipInventorySlot[2];
    [SerializeField] private ItemCreator itemCreator;

    private List<string> EquipSaveList;


    public void LoadEquip()
    {
        if (!File.Exists(Application.persistentDataPath + "/saves.json"))
        {
            Debug.LogWarning("Файл сохранения не найден: " + Application.persistentDataPath);
            return;
        }

        string json = File.ReadAllText(Application.persistentDataPath + "/EquipSaves.json");
        EquipSaveList = JsonConvert.DeserializeObject<List<string>>(json);

        for (int i = 0; i < EquipSaveList.Count; i++)
        {
            equipSlots[i].SetItem(itemCreator.GetItemData(EquipSaveList[i]) as EquipItemData);
        }

    }

}
