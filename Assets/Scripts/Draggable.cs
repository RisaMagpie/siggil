using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;


using UnityEngine.SceneManagement;

using System.Collections.Generic;

public class Draggable : MonoBehaviour,  IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    public Vector3 startPos;
    public Transform oldPlaceholderParent = null;
    GameObject placeholder = null;

    public enum ZoneType {ORDINARY,SPIRIT,NOTFORDROP};
    public ZoneType typeOfZone = ZoneType.ORDINARY;

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag != null)
        {
            CardController card = eventData.pointerDrag.GetComponent<CardController>();
            if (card != null && card.IsFree)
            {
                placeholder = new GameObject();
                placeholder.transform.SetParent(this.transform.parent);

                LayoutElement place = placeholder.AddComponent<LayoutElement>();
                place.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
                place.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
                place.flexibleWidth = 0;
                place.flexibleHeight = 0;

                placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

                parentToReturnTo = this.transform.parent;

                placeholderParent = parentToReturnTo;
                oldPlaceholderParent = parentToReturnTo;

                this.transform.SetParent(this.transform.parent.parent);

                GetComponent<CanvasGroup>().blocksRaycasts = false;
                this.startPos = this.transform.position;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag != null)
        {
            //Debug.Log ("OnDrag");
            CardController card = eventData.pointerDrag.GetComponent<CardController>();

            if (card != null && card.IsFree)
            {

                this.transform.position = eventData.position;

                if (placeholder.transform.parent != placeholderParent)
                    placeholder.transform.SetParent(placeholderParent);

                int newSiblingIndex = placeholderParent.childCount;

                for (int i = 0; i < placeholderParent.childCount; i++)
                {
                    if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                    {
                        newSiblingIndex = i;

                        if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                            newSiblingIndex--;

                        break;
                    }
                }
                placeholder.transform.SetSiblingIndex(newSiblingIndex);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Draggable obj = eventData.pointerDrag.GetComponent<Draggable>();
        if (eventData.pointerDrag != null)
        {
            CardController card = eventData.pointerDrag.GetComponent<CardController>();

            if (card.IsFree)
            {
                //Debug.Log(oldParentToReturnTo);

                    this.transform.SetParent(parentToReturnTo);
                    this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    Destroy(placeholder);
            }
        }
    }
}
