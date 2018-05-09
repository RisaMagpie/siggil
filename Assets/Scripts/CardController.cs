using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CardController : MonoBehaviour {

    public static bool cantDoAnything = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _state = 0;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }

    void flipCard()
    {
        if (_state == 0 && !cantDoAnything)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state ==1 && !cantDoAnything)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { initialized = value; }
    }

    public void falseCheck() {
        StartCoroutine(pause ());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (state == 1)
            GetComponent<Image>().sprite = _cardFace;
    }
}
