using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PopUpMenuOpener : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private InventorySlot slot;
    [Inject] private PopUpMenu _popUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (slot.item != null)
        {
            _popUp.OpenPopUp(slot);
        }
    }
}
