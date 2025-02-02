using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;      // �������� ��������
    public Sprite icon;          // ������ ��������
    public string itemType;      // ��� �������� (������, ������ � �. �.)
    public int maxStack;         // ������������ ���������� � ����� ������
    public float mass;           // ����� ��������
}
