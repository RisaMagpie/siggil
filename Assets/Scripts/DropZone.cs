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
            /*_manager.GetComponent<GameManager>().currentCard = card;
            if (gameObject.tag == "Spirit")
                _manager.GetComponent<GameManager>().GameObjectName = gameObject.tag;
            else
                _manager.GetComponent<GameManager>().GameObjectName = gameObject.name;*/


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
                    //obj.parentToReturnTo = this.transform;
                    //obj.parentToReturnTo = gameObject.transform;
                    _manager.GetComponent<GameManager>().SetFreeCards(card.NumOfPosition);
                    _manager.GetComponent<GameManager>().IsLastGoToDrop = true;
                    _manager.GetComponent<GameManager>().cardsOnHand.Remove(card);
                    Destroy(eventData.pointerDrag);
                }
                else if ((typeOfZone == card.Type) && gameObject.name == "Hand" && (_manager.GetComponent<GameManager>().IsLastGoToDrop))
                {
                    //obj.parentToReturnTo = this.transform;
                    obj.parentToReturnTo = gameObject.transform;

                    card.GetComponent<CardController>().transform.SetParent(gameObject.transform);
                    card.GetComponent<CardController>().ZoneName = "Hand";
                    _manager.GetComponent<GameManager>().cardsOnHand.Add(card);
                    

                    _manager.GetComponent<GameManager>().SetFreeCards(card.NumOfPosition);
                    _manager.GetComponent<GameManager>().IsLastGoToDrop = false;                    
                }
                /*else if ((typeOfZone == card.Type) && gameObject.tag == "Spirit" && (gameObject.transform.childCount==1))
                {
                    
                    _manager.GetComponent<GameManager>().NumOfEmptySpiritSlots--;
                    obj.parentToReturnTo = this.transform;
                    _manager.GetComponent<GameManager>().SetFreeCards(card.NumOfPosition);
                }*/
                else
                {                    
                   /* obj.parentToReturnTo = obj.oldPlaceholderParent;
                    obj.transform.SetParent(obj.oldPlaceholderParent);
                    obj.transform.SetAsFirstSibling();           
                    
                    obj.GetComponent<CanvasGroup>().blocksRaycasts = true;//TODO find a mistake
                    obj.transform.position = obj.startPos;*/

                    
                    card.transform.SetParent(obj.oldPlaceholderParent);
                    card.transform.SetAsFirstSibling();
                    //card.GetComponent<CanvasGroup>().blocksRaycasts = true;//TODO find a mistake
                    card.transform.position = obj.startPos;
                }
                //_manager.GetComponent<GameManager>().GameOver(3);
            }
        }

    }
}
