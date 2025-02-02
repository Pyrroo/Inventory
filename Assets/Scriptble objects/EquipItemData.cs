using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/EquipItem")]
public class EquipItemData : ItemData
{
    public string BodyPart; // ���� �������
    public int armor;       // ������� ������
}
