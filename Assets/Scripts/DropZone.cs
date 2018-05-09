using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    //public Draggable.CardType typeOfCard = Draggable.CardType.ORDINARY;
    public bool isForAllCards = true;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (obj != null)
        {
           // if (typeOfCard == obj.typeOfCard || isForAllCards)
            //{
                obj.parentToReturnTo = this.transform;
            //}
        }
    }
}
