using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.ZoneType typeOfZone = Draggable.ZoneType.NOTFORDROP;
    private GameObject _manager;
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag != null)
        {
            Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
            CardController card = eventData.pointerDrag.GetComponent<CardController>();
            if (card.IsFree)
            {
                //Debug.Log("OnPointerEnter");
                if (eventData.pointerDrag == null)
                    return;

                if (obj != null)
                {
                    obj.placeholderParent = this.transform;
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag != null)
        {
            Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
            CardController card = eventData.pointerDrag.GetComponent<CardController>();

            if (card != null && card.IsFree)
            {
                //Debug.Log("OnPointerExit");
                if (eventData.pointerDrag == null)
                    return;

                if (obj != null && obj.placeholderParent == this.transform)
                {
                    obj.placeholderParent = obj.parentToReturnTo;
                }
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag != null)
        {
            Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
            CardController card = eventData.pointerDrag.GetComponent<CardController>();

            if (card != null && card.IsFree)
            {
                Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

                if ((typeOfZone == card.Type) && gameObject.name == "DropZone" && !(_manager.GetComponent<GameManager>().IsLastGoToDrop))
                {
                    obj.parentToReturnTo = this.transform;
                    _manager.GetComponent<GameManager>().SetFreeCards(card.NumOfPosition);
                    Destroy(eventData.pointerDrag);
                    _manager.GetComponent<GameManager>().IsLastGoToDrop = true;
                }
                else if ((typeOfZone == card.Type) && gameObject.name == "Hand" && (_manager.GetComponent<GameManager>().IsLastGoToDrop))
                {
                    obj.parentToReturnTo = this.transform;
                    _manager.GetComponent<GameManager>().SetFreeCards(card.NumOfPosition);
                    _manager.GetComponent<GameManager>().IsLastGoToDrop = false;
                }
                else if ((typeOfZone == card.Type) && gameObject.tag == "Spirit")
                {
                    obj.parentToReturnTo = this.transform;
                    _manager.GetComponent<GameManager>().SetFreeCards(card.NumOfPosition);
                }

                else
                {
                    obj.transform.position = obj.startPos;
                    obj.parentToReturnTo = obj.oldPlaceholderParent;
                    obj.transform.SetAsLastSibling();
                    obj.GetComponent<CanvasGroup>().blocksRaycasts = true;//TODO find a mistake
                }
            }
        }

    }
}
