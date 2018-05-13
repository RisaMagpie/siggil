using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CardController : MonoBehaviour {

    //public static bool cantDoAnything = false;

    [SerializeField]
    private bool _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    // [SerializeField]
    // private string _cardClass;


    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _state = true;//create other state for each card
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void SetupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().GetCardBack();
        _cardFace = _manager.GetComponent<GameManager>().GetCardFace(_cardValue);
        FlipCard();
    }

    public void FlipCard()
    {
        _state = !_state;

        if (!_state)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int CardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public bool State
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool Initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }
}
