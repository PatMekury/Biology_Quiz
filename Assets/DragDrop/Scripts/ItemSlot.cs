using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameObject resultDisplay; // Reference to the result display GameObject attached to this slot
    public DragDrop currentObjectInSlot = null; // Reference to the currently dropped object

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // Set the current object in the slot
            currentObjectInSlot = eventData.pointerDrag.GetComponent<DragDrop>();
            RectTransform rectTransform = GetComponent<RectTransform>();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
        }
    }

    public void OnItemDropped(DragDrop item)
    {
        // Handle the fact that an item has been dropped into this slot
        currentObjectInSlot = item;
        Debug.Log("Item dropped into slot: " + item.parentGameObject.name);
    }

}
