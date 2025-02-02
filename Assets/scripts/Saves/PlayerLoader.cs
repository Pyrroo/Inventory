using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class PlayerLoader : MonoBehaviour
{
    [SerializeField] private EnemySystem enemy;
    private List<int> HealthLoadList;
    public void LoadHealth()
    {
        if (!File.Exists(Application.persistentDataPath + "/saves.json"))
        {
            Debug.LogWarning("Файл сохранения не найден: " + Application.persistentDataPath);
            return;
        }

        string json = File.ReadAllText(Application.persistentDataPath + "/Health.json");
        HealthLoadList = JsonConvert.DeserializeObject<List<int>>(json);

        HealthSystem.Instance.SetHealth(HealthLoadList[0]);
        enemy.SetHealth(HealthLoadList[1]);
    }
}
