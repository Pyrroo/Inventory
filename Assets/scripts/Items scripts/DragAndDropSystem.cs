using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DragAndFropSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private InventorySlot originalSlot;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Transform parentAfterDrag;

    private Vector2 StartPos;
    private Canvas canvas;
    private GraphicRaycaster raycaster;
    private void Start()
    {
        raycaster = GetComponentInParent<GraphicRaycaster>();
        canvas = GetComponentInParent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        StartPos = transform.position;

        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform, true); // Временно переносим на Canvas
        transform.SetAsLastSibling();


    }
    public void OnDrag(PointerEventData eventData)
    {
        if(originalSlot.item != null)        
        rectTransform.position = eventData.position;  
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag, true);

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);

        foreach (var hit in results)
        {
            InventorySlot hitSlot = hit.gameObject.GetComponent<InventorySlot>();

            if (hitSlot != null && hitSlot != originalSlot)
            {
                if(hitSlot.item != null)
                {
                    InventorySlot temp = originalSlot.gameObject.AddComponent<InventorySlot>();
                    temp.CopySlot(hitSlot);

                    hitSlot.ReSetSlot(originalSlot);
                    originalSlot.ReSetSlot(temp);

                    Destroy(temp);
                    transform.position = StartPos;
                    return;
                }
                else
                {
                    InventorySlot temp = originalSlot.gameObject.AddComponent<InventorySlot>();
                    temp.CopySlot(hitSlot);

                    hitSlot.ReSetSlot(originalSlot);
                    originalSlot.DoEmpty();

                    Destroy(temp);
                    transform.position = StartPos;
                    return;
                }
            }
        }
        transform.position = StartPos;

    }
}
