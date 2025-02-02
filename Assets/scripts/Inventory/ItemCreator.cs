using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public ItemData[] DataArray = new ItemData[7];
    [SerializeField] InventoryLoader loader;


    public void CreateRifleAmmo(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[0], count);
    }
    public void CreatePistolAmmo(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[1], count);
    }
    public void CreateFirstAidKit(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[2], count);
    }
    public void CreateCap(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[3], count);
    }
    public void CreateHelmet(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[4], count);
    }
    public void CreateJacket(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[5], count);
    }
    public void CreateBodyArmor(int count)
    {
        InventoryCore.Instance.AddItem(DataArray[6], count);
    }
    public void CreateItem(ItemData item, int count)
    {
        InventoryCore.Instance.AddItem(item, count);
    }

    public ItemData GetItemData(string name)
    {
        for (int i = 0; i < DataArray.Length; i++ )
        {
            if (DataArray[i].itemName == name)
            {
                return DataArray[i];
            }               
        }
        return null;
    }

    public void CreateRandomItem()
    {
        switch (Random.Range(1, 8))
        {
            case 1:
                CreateBodyArmor(1);
                break;
            case 2:
                CreateCap(1);
                break;
            case 3:
                CreateFirstAidKit(6);
                break;
            case 4:
                CreateHelmet(1);
                break;
            case 5:
                CreateJacket(1);
                break;
            case 6:
                CreatePistolAmmo(50);
                break;
            case 7:
                CreateRifleAmmo(100);
                break;
        }
    }


    public void GenerateAllItems()
    {
        CreateBodyArmor(1);
        CreateCap(1);
        CreateFirstAidKit(6);
        CreateHelmet(1);
        CreateJacket(1);
        CreatePistolAmmo(50);
        CreateRifleAmmo(100);
    }

    public void GenerateLoadedItems()
    {
        List<KeyValuePair<string, int>> ItemSaveList;
        ItemSaveList = loader.LoadSave();
        if (ItemSaveList !=null)
        {
            for (int i = 0; i < ItemSaveList.Count; i++)
            {
                for (int j = 0; j < Mathf.Min(ItemSaveList.Count, DataArray.Length); j++)
                {
                    if (DataArray[j].itemName == ItemSaveList[i].Key)
                        CreateItem(DataArray[j], ItemSaveList[i].Value);
                }
            }
        }
        
    }
}
