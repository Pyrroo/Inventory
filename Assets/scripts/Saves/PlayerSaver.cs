using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlayerSaver : MonoBehaviour
{
    [SerializeField] private EnemySystem enemy;
    private List<int> HealthSaveList = new List<int>();

    private void OnApplicationQuit()
    {
        HealthSaveList.Add(HealthSystem.Instance.GetHealth());
        HealthSaveList.Add(enemy.GetHealth());

        File.WriteAllText(Path.Combine(Application.persistentDataPath, "Health.json"), JsonConvert.SerializeObject(HealthSaveList, Formatting.Indented));
    }
}
