using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text numOfSpirits;

    private bool _init = false;
    private int _numOfSpirits = 0;    
    
	// Update is called once per frame
	void Update () {
        numOfSpirits.text = "Spirits: " + _numOfSpirits + "/7";
        if (!_init)
            InitializeCards();

        //if (Input.GetMouseButtonUp(0))
          //  CheckCards();
    }

    void InitializeCards()
    {

        for (int i=1; i < 57; i++)
        {
            bool test=false;
            int choice = 0;
            while (!test)
            {
                choice = Random.Range(0, cards.Length);
                test = !(cards[choice].GetComponent<CardController>().Initialized);
            }
            cards[choice].GetComponent<CardController>().CardValue = i;
            cards[choice].GetComponent<CardController>().Initialized = true;

            if (i > 47 && i!=55)
                cards[choice].GetComponent<CardController>().IsSpirit = true;
            else
                cards[choice].GetComponent<CardController>().IsSpirit = false;


        }

        List<int> cardNumList = new List<int>() {0,1,2,3,4,5,6,13,14,15,16,17,28,29,22,23,24,27,30,31,32,33,34,41,42,43,44,45,50,51,52,55};
        foreach (int num in cardNumList)
            cards[num].GetComponent<CardController>().IsFaceUp = false;

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
