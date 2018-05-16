using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text numOfSpirits;
    public List<int> cardsInGame;
    private bool _isLastGoToDrop = false;

    private bool _init = false;
    private int _numOfSpirits = 0;

    // Update is called once per frame
    void Update()
    {
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
        int[] stoneCards = new int[] { 18, 17, 7, 13, 16, 8, 9, 55 };
        int[] deerCards = new int[] { 6, 4, 56, 5, 3, 2, 1, 49 };
        int[] leafCards = new int[] { 34, 31, 36, 33, 35, 32, 28, 54 };
        int[] turtleCards = new int[] { 10, 12, 15, 11, 14, 25, 26, 50 };
        int[] cloudCards = new int[] { 37, 42, 46, 39, 48, 38, 47, 52 };
        int[] waterCards = new int[] { 19, 24, 20, 23, 21, 27, 22, 53 };
        int[] featherCards = new int[] { 30, 45, 41, 43, 29, 44, 40, 51 };
        int index;


        for (int i = 1; i < 57; i++)
        {
            bool test = false;
            int choice = 0;
            while (!test)
            {
                choice = UnityEngine.Random.Range(0, cards.Length);
                test = !(cards[choice].GetComponent<CardController>().Initialized);
            }
            cards[choice].GetComponent<CardController>().CardValue = i;
            cards[choice].GetComponent<CardController>().NumOfPosition = choice;
            cards[choice].GetComponent<CardController>().Initialized = true;

            if (Array.Exists(stoneCards, element => element == i))
            {
                cards[choice].GetComponent<CardController>().Kind = CardController.CardKind.STONE;
                index = Array.IndexOf(stoneCards, i) + 1;
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

        int[] cardNumList = new int[] { 0, 1, 2, 3, 4, 5, 6, 13, 14, 15, 16, 17, 28, 29, 22, 23, 24, 27, 30, 31, 32, 33, 34, 41, 42, 43, 44, 45, 50, 51, 52, 55 };
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
        return cardFace[i - 1];
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
            //left row
            case 22:
                {
                    cardsInGame.Add(22);
                    AddNewFreeCard(18);
                    if (cardsInGame.Exists(x => x == 23)) { AddNewFreeCard(19); }
                    break;
                }
            case 23:
                {
                    cardsInGame.Add(23);
                    if (cardsInGame.Exists(x => x == 22)) { AddNewFreeCard(19); }
                    if (cardsInGame.Exists(x => x == 24)) { AddNewFreeCard(20); }
                    break;
                }
            case 24:
                {
                    cardsInGame.Add(24);
                    AddNewFreeCard(21);
                    if (cardsInGame.Exists(x => x == 23)) { AddNewFreeCard(20); }
                    break;
                }
            //right row
            case 50:
                {
                    cardsInGame.Add(50);
                    AddNewFreeCard(46);
                    if (cardsInGame.Exists(x => x == 51)) { AddNewFreeCard(47); }
                    break;
                }
            case 51:
                {
                    cardsInGame.Add(51);
                    if (cardsInGame.Exists(x => x == 50)) { AddNewFreeCard(47); }
                    if (cardsInGame.Exists(x => x == 52)) { AddNewFreeCard(48); }
                    break;
                }
            case 52:
                {
                    cardsInGame.Add(52);
                    AddNewFreeCard(49);
                    if (cardsInGame.Exists(x => x == 51)) { AddNewFreeCard(48); }
                    break;
                }
            //forth level
            //left row
            case 18:
                {
                    cardsInGame.Add(18);
                    AddNewFreeCard(13);
                    if (cardsInGame.Exists(x => x == 19)) { AddNewFreeCard(14); }
                    break;
                }
            case 19:
                {
                    cardsInGame.Add(19);
                    if (cardsInGame.Exists(x => x == 18)) { AddNewFreeCard(14); }
                    if (cardsInGame.Exists(x => x == 20)) { AddNewFreeCard(15); }
                    break;
                }
            case 20:
                {
                    cardsInGame.Add(20);
                    if (cardsInGame.Exists(x => x == 19)) { AddNewFreeCard(15); }
                    if (cardsInGame.Exists(x => x == 21)) { AddNewFreeCard(16); }
                    break;
                }
            case 21:
                {
                    cardsInGame.Add(21);
                    AddNewFreeCard(17);
                    if (cardsInGame.Exists(x => x == 20)) { AddNewFreeCard(16); }
                    break;
                }
            //right row
            case 46:
                {
                    cardsInGame.Add(46);
                    AddNewFreeCard(41);
                    if (cardsInGame.Exists(x => x == 47)) { AddNewFreeCard(42); }
                    break;
                }
            case 47:
                {
                    cardsInGame.Add(47);
                    if (cardsInGame.Exists(x => x == 46)) { AddNewFreeCard(42); }
                    if (cardsInGame.Exists(x => x == 48)) { AddNewFreeCard(43); }
                    break;
                }
            case 48:
                {
                    cardsInGame.Add(48);
                    if (cardsInGame.Exists(x => x == 47)) { AddNewFreeCard(43); }
                    if (cardsInGame.Exists(x => x == 49)) { AddNewFreeCard(44); }
                    break;
                }
            case 49:
                {
                    cardsInGame.Add(49);
                    AddNewFreeCard(45);
                    if (cardsInGame.Exists(x => x == 48)) { AddNewFreeCard(44); }
                    break;
                }
            //fifth level
            //left row
            case 13:
                {
                    cardsInGame.Add(13);
                    AddNewFreeCard(7);
                    if (cardsInGame.Exists(x => x == 14)) { AddNewFreeCard(8); }
                    break;
                }
            case 14:
                {
                    cardsInGame.Add(14);
                    if (cardsInGame.Exists(x => x == 13)) { AddNewFreeCard(8); }
                    if (cardsInGame.Exists(x => x == 15)) { AddNewFreeCard(9); }
                    break;
                }
            case 15:
                {
                    cardsInGame.Add(15);
                    if (cardsInGame.Exists(x => x == 14)) { AddNewFreeCard(9); }
                    if (cardsInGame.Exists(x => x == 16)) { AddNewFreeCard(10); }
                    break;
                }
            case 16:
                {
                    cardsInGame.Add(16);
                    if (cardsInGame.Exists(x => x == 15)) { AddNewFreeCard(10); }
                    if (cardsInGame.Exists(x => x == 17)) { AddNewFreeCard(11); }
                    break;
                }
            case 17:
                {
                    cardsInGame.Add(17);
                    AddNewFreeCard(12);
                    if (cardsInGame.Exists(x => x == 16)) { AddNewFreeCard(11); }
                    break;
                }
            //right row
            case 41:
                {
                    cardsInGame.Add(41);
                    AddNewFreeCard(35);
                    if (cardsInGame.Exists(x => x == 42)) { AddNewFreeCard(36); }
                    break;
                }
            case 42:
                {
                    cardsInGame.Add(42);
                    if (cardsInGame.Exists(x => x == 41)) { AddNewFreeCard(36); }
                    if (cardsInGame.Exists(x => x == 43)) { AddNewFreeCard(37); }
                    break;
                }
            case 43:
                {
                    cardsInGame.Add(43);
                    if (cardsInGame.Exists(x => x == 42)) { AddNewFreeCard(37); }
                    if (cardsInGame.Exists(x => x == 44)) { AddNewFreeCard(38); }
                    break;
                }
            case 44:
                {
                    cardsInGame.Add(44);
                    if (cardsInGame.Exists(x => x == 43)) { AddNewFreeCard(38); }
                    if (cardsInGame.Exists(x => x == 45)) { AddNewFreeCard(39); }
                    break;
                }
            case 45:
                {
                    cardsInGame.Add(45);
                    AddNewFreeCard(40);
                    if (cardsInGame.Exists(x => x == 44)) { AddNewFreeCard(39); }
                    break;
                }
            //sixth level
            //left row
            case 7:
                {
                    cardsInGame.Add(7);
                    AddNewFreeCard(0);
                    if (cardsInGame.Exists(x => x == 8)) { AddNewFreeCard(1); }
                    break;
                }
            case 8:
                {
                    cardsInGame.Add(8);
                    if (cardsInGame.Exists(x => x == 7)) { AddNewFreeCard(1); }
                    if (cardsInGame.Exists(x => x == 9)) { AddNewFreeCard(2); }
                    break;
                }
            case 9:
                {
                    cardsInGame.Add(9);
                    if (cardsInGame.Exists(x => x == 8)) { AddNewFreeCard(2); }
                    if (cardsInGame.Exists(x => x == 10)) { AddNewFreeCard(3); }
                    break;
                }
            case 10:
                {
                    cardsInGame.Add(10);
                    if (cardsInGame.Exists(x => x == 9)) { AddNewFreeCard(3); }
                    if (cardsInGame.Exists(x => x == 11)) { AddNewFreeCard(4); }
                    break;
                }
            case 11:
                {
                    cardsInGame.Add(11);
                    if (cardsInGame.Exists(x => x == 10)) { AddNewFreeCard(4); }
                    if (cardsInGame.Exists(x => x == 12)) { AddNewFreeCard(5); }
                    break;
                }
            case 12:
                {
                    cardsInGame.Add(12);
                    AddNewFreeCard(6);
                    if (cardsInGame.Exists(x => x == 11)) { AddNewFreeCard(5); }
                    break;
                }
            //right row
            case 35:
                {
                    cardsInGame.Add(35);
                    AddNewFreeCard(28);
                    if (cardsInGame.Exists(x => x == 36)) { AddNewFreeCard(29); }
                    break;
                }
            case 36:
                {
                    cardsInGame.Add(36);
                    if (cardsInGame.Exists(x => x == 35)) { AddNewFreeCard(29); }
                    if (cardsInGame.Exists(x => x == 37)) { AddNewFreeCard(30); }
                    break;
                }
            case 37:
                {
                    cardsInGame.Add(37);
                    if (cardsInGame.Exists(x => x == 36)) { AddNewFreeCard(30); }
                    if (cardsInGame.Exists(x => x == 38)) { AddNewFreeCard(31); }
                    break;
                }
            case 38:
                {
                    cardsInGame.Add(38);
                    if (cardsInGame.Exists(x => x == 37)) { AddNewFreeCard(31); }
                    if (cardsInGame.Exists(x => x == 39)) { AddNewFreeCard(32); }
                    break;
                }
            case 39:
                {
                    cardsInGame.Add(39);
                    if (cardsInGame.Exists(x => x == 38)) { AddNewFreeCard(32); }
                    if (cardsInGame.Exists(x => x == 40)) { AddNewFreeCard(33); }
                    break;
                }
            case 40:
                {
                    cardsInGame.Add(40);
                    AddNewFreeCard(34);
                    if (cardsInGame.Exists(x => x == 39)) { AddNewFreeCard(33); }
                    break;
                }
        }

    }

    private void AddNewFreeCard(int numOfCard)
    {
        cards[numOfCard].GetComponent<CardController>().IsFree = true;
        cards[numOfCard].GetComponent<CardController>().FlipCard();
    }

    public bool IsLastGoToDrop
    {
        get { return _isLastGoToDrop; }
        set { _isLastGoToDrop = value; }
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
