using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{


    /// <summary>
    /// /*
    /// </summary>

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text numOfSpirits;
    public List<int> cardsInGame;
    private bool _isLastGoToDrop = false;

    private bool _init = false;
    private int _numOfSpirits = 0;
    private int _numOfEmptySpiritSlots = 3;

    private int _capacityOfClickedCards=0;
    public CardController currentCard;

    public List<CardController> clickedCards=new List<CardController>();
    public List<CardController> cardsOnHand = new List<CardController>();

    private int _clickedCardsNum;
    private CardController.CardKind _clickedCardsKind;
    private bool _isNumTheSame=true;
    private bool _isKindTheSame=true;
    public string GameObjectName;

    private int _currentCardNum;
    private CardController.CardKind _currentCardKind;

    public GameObject gameOverPanel;
    public Text gameOverText;

    public List<GameObject> spiritsSlots = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {

        numOfSpirits.text = "Spirits: " + _numOfSpirits + "/7";
        if (!_init)
        {
            InitializeCards();
            gameOverPanel.SetActive(false);            
        }

       // if (Input.GetMouseButtonUp(0))
        //{
            


         //   CheckCards();
        //}
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



        foreach (GameObject c in cards)
            c.GetComponent<CardController>().SetupGraphics();

        if (!_init)
            _init = true;

        //cards[27].GetComponent<CardController>().IsFree = true;
        StartCoroutine(PauseCoroutine(27));
        //AddNewFreeCard(27);
        StartCoroutine(PauseCoroutine(55));
        //cards[55].GetComponent<CardController>().IsFree = true;
        //AddNewFreeCard(55);
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
       // StartCoroutine(PauseCoroutine());
        switch (numOfPrevCard)
        {
            //first level
            case 27:
                {
                    cardsInGame.Add(27);
                    StartCoroutine(PauseCoroutine(25));
                    StartCoroutine(PauseCoroutine(26));
                    break;
                }
            case 55:
                {
                    cardsInGame.Add(55);
                    StartCoroutine(PauseCoroutine(53));
                    StartCoroutine(PauseCoroutine(54));
                    break;
                }
            //second level
            case 25:
                {
                    cardsInGame.Add(25);
                    StartCoroutine(PauseCoroutine(22));
                    if (cardsInGame.Exists(x => x == 26)) { StartCoroutine(PauseCoroutine(23)); ; }
                    break;
                }
            case 26:
                {
                    cardsInGame.Add(26);
                    StartCoroutine(PauseCoroutine(24));
                    if (cardsInGame.Exists(x => x == 25)) { StartCoroutine(PauseCoroutine(23)); ; }
                    break;
                }
            case 53:
                {
                    cardsInGame.Add(53);
                    StartCoroutine(PauseCoroutine(50));
                    if (cardsInGame.Exists(x => x == 54)) { StartCoroutine(PauseCoroutine(51)); ; }
                    break;
                }
            case 54:
                {
                    cardsInGame.Add(54);
                    StartCoroutine(PauseCoroutine(52));
                    if (cardsInGame.Exists(x => x == 53)) { StartCoroutine(PauseCoroutine(51)); ; }
                    break;
                }
            //third level
            //left row
            case 22:
                {
                    cardsInGame.Add(22);
                    StartCoroutine(PauseCoroutine(18));
                    if (cardsInGame.Exists(x => x == 23)) { StartCoroutine(PauseCoroutine(19));  }
                    break;
                }
            case 23:
                {
                    cardsInGame.Add(23);
                    if (cardsInGame.Exists(x => x == 22)) { StartCoroutine(PauseCoroutine(19));  }
                    if (cardsInGame.Exists(x => x == 24)) { StartCoroutine(PauseCoroutine(20)); }
                    break;
                }
            case 24:
                {
                    cardsInGame.Add(24);
                    StartCoroutine(PauseCoroutine(21));
                    if (cardsInGame.Exists(x => x == 23)) { StartCoroutine(PauseCoroutine(20)); ; }
                    break;
                }
            //right row
            case 50:
                {
                    cardsInGame.Add(50);
                    StartCoroutine(PauseCoroutine(46));
                    if (cardsInGame.Exists(x => x == 51)) { StartCoroutine(PauseCoroutine(47));  }
                    break;
                }
            case 51:
                {
                    cardsInGame.Add(51);
                    if (cardsInGame.Exists(x => x == 50)) { StartCoroutine(PauseCoroutine(47)); }
                    if (cardsInGame.Exists(x => x == 52)) { StartCoroutine(PauseCoroutine(48)); }
                    break;
                }
            case 52:
                {
                    cardsInGame.Add(52);
                    StartCoroutine(PauseCoroutine(49));
                    if (cardsInGame.Exists(x => x == 51)) { StartCoroutine(PauseCoroutine(48));  }
                    break;
                }
            //forth level
            //left row
            case 18:
                {
                    cardsInGame.Add(18);
                    StartCoroutine(PauseCoroutine(13));
                    if (cardsInGame.Exists(x => x == 19)) { StartCoroutine(PauseCoroutine(14));  }
                    break;
                }
            case 19:
                {
                    cardsInGame.Add(19);
                    if (cardsInGame.Exists(x => x == 18)) { StartCoroutine(PauseCoroutine(14)); }
                    if (cardsInGame.Exists(x => x == 20)) { StartCoroutine(PauseCoroutine(15)); }
                    break;
                }
            case 20:
                {
                    cardsInGame.Add(20);
                    if (cardsInGame.Exists(x => x == 19)) { StartCoroutine(PauseCoroutine(15));  }
                    if (cardsInGame.Exists(x => x == 21)) { StartCoroutine(PauseCoroutine(16)); }
                    break;
                }
            case 21:
                {
                    cardsInGame.Add(21);
                    StartCoroutine(PauseCoroutine(17));
                    if (cardsInGame.Exists(x => x == 20)) { StartCoroutine(PauseCoroutine(16)); }
                    break;
                }
            //right row
            case 46:
                {
                    cardsInGame.Add(46);
                    StartCoroutine(PauseCoroutine(41));
                    if (cardsInGame.Exists(x => x == 47)) { StartCoroutine(PauseCoroutine(42)); }
                    break;
                }
            case 47:
                {
                    cardsInGame.Add(47);
                    if (cardsInGame.Exists(x => x == 46)) { StartCoroutine(PauseCoroutine(42)); }
                    if (cardsInGame.Exists(x => x == 48)) { StartCoroutine(PauseCoroutine(43)); }
                    break;
                }
            case 48:
                {
                    cardsInGame.Add(48);
                    if (cardsInGame.Exists(x => x == 47)) { StartCoroutine(PauseCoroutine(43)); }
                    if (cardsInGame.Exists(x => x == 49)) { StartCoroutine(PauseCoroutine(44)); }
                    break;
                }
            case 49:
                {
                    cardsInGame.Add(49);
                    StartCoroutine(PauseCoroutine(45));
                    if (cardsInGame.Exists(x => x == 48)) { StartCoroutine(PauseCoroutine(44)); }
                    break;
                }
            //fifth level
            //left row
            case 13:
                {
                    cardsInGame.Add(13);
                    StartCoroutine(PauseCoroutine(7));
                    if (cardsInGame.Exists(x => x == 14)) { StartCoroutine(PauseCoroutine(8)); }
                    break;
                }
            case 14:
                {
                    cardsInGame.Add(14);
                    if (cardsInGame.Exists(x => x == 13)) { StartCoroutine(PauseCoroutine(8)); }
                    if (cardsInGame.Exists(x => x == 15)) { StartCoroutine(PauseCoroutine(9)); }
                    break;
                }
            case 15:
                {
                    cardsInGame.Add(15);
                    if (cardsInGame.Exists(x => x == 14)) { StartCoroutine(PauseCoroutine(9)); }
                    if (cardsInGame.Exists(x => x == 16)) { StartCoroutine(PauseCoroutine(10)); }
                    break;
                }
            case 16:
                {
                    cardsInGame.Add(16);
                    if (cardsInGame.Exists(x => x == 15)) { StartCoroutine(PauseCoroutine(10)); }
                    if (cardsInGame.Exists(x => x == 17)) { StartCoroutine(PauseCoroutine(11)); }
                    break;
                }
            case 17:
                {
                    cardsInGame.Add(17);
                    StartCoroutine(PauseCoroutine(12));
                    if (cardsInGame.Exists(x => x == 16)) { StartCoroutine(PauseCoroutine(11)); }
                    break;
                }
            //right row
            case 41:
                {
                    cardsInGame.Add(41);
                    StartCoroutine(PauseCoroutine(35));
                    if (cardsInGame.Exists(x => x == 42)) { StartCoroutine(PauseCoroutine(36)); }
                    break;
                }
            case 42:
                {
                    cardsInGame.Add(42);
                    if (cardsInGame.Exists(x => x == 41)) { StartCoroutine(PauseCoroutine(36)); }
                    if (cardsInGame.Exists(x => x == 43)) { StartCoroutine(PauseCoroutine(37)); }
                    break;
                }
            case 43:
                {
                    cardsInGame.Add(43);
                    if (cardsInGame.Exists(x => x == 42)) { StartCoroutine(PauseCoroutine(37)); }
                    if (cardsInGame.Exists(x => x == 44)) { StartCoroutine(PauseCoroutine(38)); }
                    break;
                }
            case 44:
                {
                    cardsInGame.Add(44);
                    if (cardsInGame.Exists(x => x == 43)) { StartCoroutine(PauseCoroutine(38)); }
                    if (cardsInGame.Exists(x => x == 45)) { StartCoroutine(PauseCoroutine(39)); }
                    break;
                }
            case 45:
                {
                    cardsInGame.Add(45);
                    StartCoroutine(PauseCoroutine(40));
                    if (cardsInGame.Exists(x => x == 44)) { StartCoroutine(PauseCoroutine(39)); }
                    break;
                }
            //sixth level
            //left row
            case 7:
                {
                    cardsInGame.Add(7);
                    StartCoroutine(PauseCoroutine(0));
                    if (cardsInGame.Exists(x => x == 8)) { StartCoroutine(PauseCoroutine(1)); }
                    break;
                }
            case 8:
                {
                    cardsInGame.Add(8);
                    if (cardsInGame.Exists(x => x == 7)) { StartCoroutine(PauseCoroutine(1)); }
                    if (cardsInGame.Exists(x => x == 9)) { StartCoroutine(PauseCoroutine(2)); }
                    break;
                }
            case 9:
                {
                    cardsInGame.Add(9);
                    if (cardsInGame.Exists(x => x == 8)) { StartCoroutine(PauseCoroutine(2)); }
                    if (cardsInGame.Exists(x => x == 10)) { StartCoroutine(PauseCoroutine(3)); }
                    break;
                }
            case 10:
                {
                    cardsInGame.Add(10);
                    if (cardsInGame.Exists(x => x == 9)) { StartCoroutine(PauseCoroutine(3)); }
                    if (cardsInGame.Exists(x => x == 11)) { StartCoroutine(PauseCoroutine(4)); }
                    break;
                }
            case 11:
                {
                    cardsInGame.Add(11);
                    if (cardsInGame.Exists(x => x == 10)) { StartCoroutine(PauseCoroutine(4)); }
                    if (cardsInGame.Exists(x => x == 12)) { StartCoroutine(PauseCoroutine(5)); }
                    break;
                }
            case 12:
                {
                    cardsInGame.Add(12);
                    StartCoroutine(PauseCoroutine(6));
                    if (cardsInGame.Exists(x => x == 11)) { StartCoroutine(PauseCoroutine(5)); }
                    break;
                }
            //right row
            case 35:
                {
                    cardsInGame.Add(35);
                    StartCoroutine(PauseCoroutine(28));
                    if (cardsInGame.Exists(x => x == 36)) { StartCoroutine(PauseCoroutine(29)); }
                    break;
                }
            case 36:
                {
                    cardsInGame.Add(36);
                    if (cardsInGame.Exists(x => x == 35)) { StartCoroutine(PauseCoroutine(29)); }
                    if (cardsInGame.Exists(x => x == 37)) { StartCoroutine(PauseCoroutine(30)); }
                    break;
                }
            case 37:
                {
                    cardsInGame.Add(37);
                    if (cardsInGame.Exists(x => x == 36)) { StartCoroutine(PauseCoroutine(30)); }
                    if (cardsInGame.Exists(x => x == 38)) { StartCoroutine(PauseCoroutine(31)); }
                    break;
                }
            case 38:
                {
                    cardsInGame.Add(38);
                    if (cardsInGame.Exists(x => x == 37)) { StartCoroutine(PauseCoroutine(31)); }
                    if (cardsInGame.Exists(x => x == 39)) { StartCoroutine(PauseCoroutine(32)); }
                    break;
                }
            case 39:
                {
                    cardsInGame.Add(39);
                    if (cardsInGame.Exists(x => x == 38)) { StartCoroutine(PauseCoroutine(32)); }
                    if (cardsInGame.Exists(x => x == 40)) { StartCoroutine(PauseCoroutine(33));  }
                    break;
                }
            case 40:
                {
                    cardsInGame.Add(40);
                    StartCoroutine(PauseCoroutine(34));
                    if (cardsInGame.Exists(x => x == 39)) { StartCoroutine(PauseCoroutine(33)); }
                    break;
                }
        }

    }

    private void AddNewFreeCard(int numOfCard)
    {
        //StartCoroutine(PauseCoroutine());

        bool spiritTransformFlag = false;

        cards[numOfCard].GetComponent<CardController>().IsFree = true;
        cards[numOfCard].GetComponent<CardController>().FlipCard();

        if (cards[numOfCard].GetComponent<CardController>().Type == Draggable.ZoneType.SPIRIT)
        {
            for (int i = 0; i < 3; i++) {
                
                if (spiritsSlots[i].transform.childCount == 0)
                {
                    //NumOfEmptySpiritSlots--;                    
                    float speed = 7f;
                    cards[numOfCard].transform.position = Vector2.Lerp(cards[numOfCard].transform.position, spiritsSlots[i].transform.position, ((speed * Time.deltaTime) / Vector2.Distance(cards[numOfCard].transform.position, spiritsSlots[i].transform.position)));
                    //cards[numOfCard].transform.position = Vector2.MoveTowards(cards[numOfCard].transform.position, spiritsSlots[i].transform.position, Vector2.Distance(cards[numOfCard].transform.position, spiritsSlots[i].transform.position));
                    SetFreeCards(cards[numOfCard].GetComponent<CardController>().NumOfPosition);
                    cards[numOfCard].transform.SetParent(spiritsSlots[i].transform);
                    //cards[numOfCard].GetComponent<CardController>().transform.SetParent(spiritsSlots[i].transform);
                    cards[numOfCard].GetComponent<CanvasGroup>().blocksRaycasts = true;//TODO find a mistake
                    cards[numOfCard].GetComponent<CardController>().ZoneName = "Spirit";                                                                   /////// cards[numOfCard].transform.position = spiritsSlots[i].transform.position;
                    spiritTransformFlag = true;
                    break;
                }
            }
            if (!spiritTransformFlag)
            {
                GameOver(2);
            }
        }
    }

    public void GameOver(int textNum)
    {
        //StartCoroutine(PauseCoroutine());
        switch (textNum)
        {
            case 1:
                {
                    gameOverPanel.SetActive(true);
                    gameOverText.text = "Game Over" + "\n" + "You won";
                    break;
                }
            case 2:
                {
                    gameOverPanel.SetActive(true);
                    gameOverText.text = "Game Over" + "\n" + "More than 3 Spirits are free";
                    break;
                }
            case 3:
                {
                    gameOverPanel.SetActive(true);
                    gameOverText.text = "Game Over" + "\n" + "You lose";
                    break;
                }
        }
    }

    public bool IsLastGoToDrop
    {
        get { return _isLastGoToDrop; }
        set { _isLastGoToDrop = value; }
    }

    public int NumOfEmptySpiritSlots
    {
        get { return _numOfEmptySpiritSlots; }
        set { _numOfEmptySpiritSlots = value; }
    }

    public int CurrentCardNum
    {
        get { return _currentCardNum; }
        set { _currentCardNum = value; }
    }

    public CardController.CardKind CurrentCardKind
    {
        get { return _currentCardKind; }
        set { _currentCardKind = value; }
    }

    public IEnumerator PauseCoroutine(int cardNum)
    {        
        yield return new WaitForSeconds(0.1f);
        AddNewFreeCard(cardNum);
    }

    public void CheckCardsOnMouseClick()
    {
        clickedCards.Add(currentCard);

        Debug.Log(_capacityOfClickedCards);
        bool inHand = cardsOnHand.Exists(element => element = currentCard);
        if (inHand || currentCard.Type == Draggable.ZoneType.SPIRIT)
        {

            if (_capacityOfClickedCards == 0 && inHand)
            {
                _clickedCardsNum = currentCard.Number;
                _clickedCardsKind = currentCard.Kind;
                _capacityOfClickedCards++;
            }
            else if (_capacityOfClickedCards < 3 && inHand)
            {

                if (_clickedCardsNum != currentCard.Number)
                {
                    _isNumTheSame = false;
                    if (!_isKindTheSame)
                    {
                        _capacityOfClickedCards = 0;
                        foreach (CardController card in clickedCards)
                            clickedCards.Remove(card);
                    }
                }
                if (_clickedCardsKind != currentCard.Kind)
                {
                    _isKindTheSame = false;
                    if (!_isNumTheSame)
                    {
                        _capacityOfClickedCards = 0;
                        foreach (CardController card in clickedCards)
                            clickedCards.Remove(card);
                    }
                }
                if (_isNumTheSame || _isNumTheSame)
                    _capacityOfClickedCards++;
            }
            else if (_capacityOfClickedCards == 3)
            {

                Debug.Log("isspirit");
                Debug.Log(currentCard.Type);
                if (currentCard.Type == Draggable.ZoneType.SPIRIT)
                {
                    Debug.Log("isspirit");
                    Debug.Log(currentCard.Type);
                    if (_clickedCardsNum != currentCard.Number)
                    {
                        _isNumTheSame = false;
                        if (!_isKindTheSame)
                        {
                            _capacityOfClickedCards = 0;
                            foreach (CardController card in clickedCards)
                                clickedCards.Remove(card);
                        }
                    }
                    if (_clickedCardsKind != currentCard.Kind)
                    {
                        _isKindTheSame = false;
                        if (!_isNumTheSame)
                        {
                            _capacityOfClickedCards = 0;
                            foreach (CardController card in clickedCards)
                                clickedCards.Remove(card);
                        }
                    }

                    if (_isNumTheSame || _isKindTheSame)
                    {
                        _numOfSpirits++;
                        numOfSpirits.text = "Spirits: " + _numOfSpirits + "/7";
                        _capacityOfClickedCards = 0;
                        foreach (CardController card in clickedCards)
                        {
                            clickedCards.Remove(card);
                            cardsOnHand.Remove(card);
                            Destroy(card);

                        }
                    }
                }
                else
                {
                    _capacityOfClickedCards = 0;
                    foreach (CardController card in clickedCards)
                        clickedCards.Remove(card);
                }
            }

        }
    }
}
