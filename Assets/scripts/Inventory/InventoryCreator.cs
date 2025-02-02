using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryCreator : MonoBehaviour
{            
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform inventoryParent;

    [Inject] private DiContainer _container;
    private InventoryCFG config;
    private GridLayoutGroup gridLayout;
    private RectTransform parentRect;
    private InventorySlot[,] slots;
    public InventorySlot[,] GenerateInventory(InventoryCFG inventoryCFG)
    {
        config = inventoryCFG;
        parentRect = inventoryParent.GetComponent<RectTransform>();
        gridLayout = inventoryParent.GetComponent<GridLayoutGroup>();
        slots = new InventorySlot [inventoryCFG.Columns, inventoryCFG.Row];

        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = config.Columns;

        AdjustCellSize();
        GenerateGrid();
        return slots;
    }
    private void AdjustCellSize()
    {   
        // ќпредел€ем размер €чеек 
        float CellSize = Mathf.Min((parentRect.rect.width - gridLayout.spacing.x * (config.Columns - 1)) / config.Columns,
                                   (parentRect.rect.height - gridLayout.spacing.y * (config.Row - 1)) / config.Row);

        gridLayout.cellSize = new Vector2(CellSize, CellSize);
    }
    private void GenerateGrid()
    {        
        for (int y = 0; y < config.Row; y++)
        {
            for (int x = 0; x < config.Columns; x++)
            {
                GameObject slotObj = _container.InstantiatePrefab(slotPrefab, inventoryParent);
                slots[x, y] = slotObj.GetComponentInChildren<InventorySlot>();
                slots[x, y].CreateSlot(null, 0);
            }
        }
        
    }
}
