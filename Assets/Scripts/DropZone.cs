using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.ZoneType typeOfZone = Draggable.ZoneType.NOTFORDROP;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (obj != null)
        {
            obj.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (obj != null && obj.placeholderParent == this.transform)
        {
            obj.placeholderParent = obj.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        CardController card = eventData.pointerDrag.GetComponent<CardController>();
        if (obj != null)
        {
            if (typeOfZone == card.Type)
            {
                obj.parentToReturnTo = this.transform;
                if (gameObject.name == "DropZone")
                    Destroy(eventData.pointerDrag);
            }
        }

    }
}
