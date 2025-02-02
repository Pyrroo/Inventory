using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class InventoryLoader : MonoBehaviour
{
    private List<KeyValuePair<string, int>> ItemSaveList = new List<KeyValuePair<string, int>>();
    public List<KeyValuePair<string, int>> LoadSave()
    {
        if (!File.Exists(Application.persistentDataPath + "/saves.json"))
        {
            Debug.LogWarning("Файл сохранения не найден: " + Application.persistentDataPath);
            return null;
        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/saves.json");
            ItemSaveList = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(json);
            return ItemSaveList;
        }
        
    }
}
