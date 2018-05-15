using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text numOfSpirits;
    public List<int> cardsInGame;

    private bool _init = false;
    private int _numOfSpirits = 0;    
    
	// Update is called once per frame
	void Update () {
        numOfSpirits.text = "Spirits: " + _numOfSpirits + "/7";
        if (!_init)
        {
            InitializeCards();
        }

        //if (Input.GetMouseButtonUp(0))
          //  CheckCards();
    }

    void InitializeCards()
    {
        int[] stoneCards = new int[] { 18,17,7,13,16,8,9,55 };
        int[] deerCards = new int[] { 6,4,56,5,3,2,1,49};
        int[] leafCards = new int[] {34,31,36,33,35,32,28,54};
        int[] turtleCards = new int[] {10,12,15,11,14,25,26,50};
        int[] cloudCards = new int[] {37,42,46,39,48,38,47,52};
        int[] waterCards = new int[] {19,24,20,23,21,27,22,53 };
        int[] featherCards = new int[] {30,45,41,43,29,44,40,51};
        int index;


        for (int i=1; i < 57; i++)
        {
            bool test=false;
            int choice = 0;
            while (!test)
            {
                choice = UnityEngine.Random.Range(0, cards.Length);
                test = !(cards[choice].GetComponent<CardController>().Initialized);
            }
            cards[choice].GetComponent<CardController>().CardValue = i;
            cards[choice].GetComponent<CardController>().NumOfPosition = choice;
            cards[choice].GetComponent<CardController>().Initialized = true;
            
            if(Array.Exists(stoneCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.STONE;
                index= Array.IndexOf(stoneCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 1;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    //cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }
            else if (Array.Exists(deerCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.DEER;
                index = Array.IndexOf(deerCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 2;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    //cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }
            else if (Array.Exists(leafCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.LEAF;
                index = Array.IndexOf(leafCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 3;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    //cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }
            else if (Array.Exists(turtleCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.TURTLE;
                index = Array.IndexOf(turtleCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 4;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    // cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }
            else if (Array.Exists(cloudCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.CLOUD;
                index = Array.IndexOf(cloudCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 5;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    //cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }
            else if (Array.Exists(waterCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.WATER;
                index = Array.IndexOf(waterCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 6;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    //  cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }
            else
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.FEATHER;
                index = Array.IndexOf(featherCards, i) + 1;
                if (index != 8)
                {
                    cards[choice].GetComponent<CardController>().Number = index;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.ORDINARY;
                }
                else
                {
                    cards[choice].GetComponent<CardController>().Number = 7;
                    cards[choice].GetComponent<CardController>().Type = Draggable.ZoneType.SPIRIT;
                    // cards[choice].GetComponent<CardController>().typeOfZone = Draggable.ZoneType.SPIRIT;
                }
            }

        }

        int[] cardNumList = new int[] {0,1,2,3,4,5,6,13,14,15,16,17,28,29,22,23,24,27,30,31,32,33,34,41,42,43,44,45,50,51,52,55};
        foreach (int num in cardNumList)
            cards[num].GetComponent<CardController>().IsFaceUp = false;

        cards[27].GetComponent<CardController>().IsFree = true;
        cards[55].GetComponent<CardController>().IsFree = true;

        foreach (GameObject c in cards)
            c.GetComponent<CardController>().SetupGraphics();

        if (!_init)
            _init = true;
    }

    public Sprite GetCardBack()
    {
        return cardBack;
    }

    public Sprite GetCardFace(int i)
    {
        return cardFace[i-1];
    }

    public void SetFreeCards(int numOfPrevCard)
    {
        switch (numOfPrevCard)
        {
            //first level
            case 27:
                {
                    cardsInGame.Add(27);
                    AddNewFreeCard(25);
                    AddNewFreeCard(26);
                    break;
                }
            case 55:
                {
                    cardsInGame.Add(55);
                    AddNewFreeCard(53);
                    AddNewFreeCard(54);
                    break;
                }
            //second level
            case 25:
                {
                    cardsInGame.Add(25);
                    AddNewFreeCard(22);
                    if (cardsInGame.Exists(x => x == 26)) { AddNewFreeCard(23); }
                    break;
                }
            case 26:
                {
                    cardsInGame.Add(26);
                    AddNewFreeCard(24);
                    if (cardsInGame.Exists(x => x == 25)) { AddNewFreeCard(23); }
                    break;
                }
            case 53:
                {
                    cardsInGame.Add(53);
                    AddNewFreeCard(50);
                    if (cardsInGame.Exists(x => x == 54)) { AddNewFreeCard(51); }
                    break;
                }
            case 54:
                {
                    cardsInGame.Add(54);
                    AddNewFreeCard(52);
                    if (cardsInGame.Exists(x => x == 53)) { AddNewFreeCard(51); }
                    break;
                }
                //third level
                /*
                case 22:
                    {
                    cardsInGame.Add();
                        AddNewFreeCard();
                        if (freeCards.Exists(x => x == 26)) { AddNewFreeCard(23); }
                        break;
                    }
                case 23:
                    {
                    cardsInGame.Add();
                        AddNewFreeCard();
                        if (freeCards.Exists(x => x == 25)) { AddNewFreeCard(23); }
                        break;
                    }
                case 24:
                    {
                    cardsInGame.Add();
                        AddNewFreeCard();
                        if (freeCards.Exists(x => x == 26)) { AddNewFreeCard(23); }
                        break;
                    }
                case 50:
                    {
                    cardsInGame.Add();
                        AddNewFreeCard();
                        if (freeCards.Exists(x => x == 25)) { AddNewFreeCard(23); }
                        break;
                    }
                case 51:
                    {
                    cardsInGame.Add();
                        AddNewFreeCard();
                        if (freeCards.Exists(x => x == 51)) { AddNewFreeCard(23); }
                        break;
                    }
                case 52:
                    {
                    cardsInGame.Add();
                        AddNewFreeCard();
                        if (freeCards.Exists(x => x == 25)) { AddNewFreeCard(23); }
                        break;
                    }
                    */


        }

    }

    private void AddNewFreeCard(int numOfCard)
    {
        cards[numOfCard].GetComponent<CardController>().IsFree = true;
        cards[numOfCard].GetComponent<CardController>().FlipCard();        
    }

   /* void CheckCards()
    {
        List<int> cardNumList = new List<int>();        
        for (int i = 0; i < cards.Length; i++)
        {
            if (!cards[i].GetComponent<CardController>().State)
            {
                cardNumList.Add(i);
                Debug.Log(i);
            }
        }

        //_matches--;
        //matchText.text = "Num" + _matches;
        
        for (int i = 0; i < cardNumList.Count; i++)
        {
            cards[cardNumList[i]].GetComponent<CardController>().State = true;
            cards[cardNumList[i]].GetComponent<CardController>().FlipOnClick();            
        }
    }*/
}
