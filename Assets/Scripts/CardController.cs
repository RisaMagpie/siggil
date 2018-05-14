using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CardController : MonoBehaviour {

    public enum CardKind {STONE,DEER,LEAF,TURTLE,CLOUD,WATER,FEATHER};

    [SerializeField]
    private bool _isFaceUp;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;
    [SerializeField]
    private bool _isSpirit;
    [SerializeField]
    private CardKind _kind;
    [SerializeField]
    private int _number;


    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _isFaceUp = true;
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
        _isFaceUp = !_isFaceUp;

        if(_isFaceUp)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int CardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public bool IsFaceUp
    {
        get { return _isFaceUp; }
        set { _isFaceUp = value; }
    }

    public bool Initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public bool IsSpirit
    {
        get { return _isSpirit; }
        set { _isSpirit = value; }
    }

    public CardKind Kind
    {
        get { return _kind; }
        set { _kind = value; }
    }

    public int Number
    {
        get { return _number; }
        set { _number = value; }
    }
}
