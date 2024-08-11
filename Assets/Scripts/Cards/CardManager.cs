using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _spritesPack1;
    [SerializeField] private Sprite[] _spritesPack2;
    [SerializeField] private Sprite[] _spritesPack3;
    [SerializeField] private Sprite[] _spritesPack4;
    [SerializeField] private Image[] _cards;

    private void Start()
    {
        InitializeCards();
    }

    private void InitializeCards()
    {
        Sprite[] _spritesPackSelected = _spritesPack1;

        switch (Random.Range(0, 5))
        { 
            case 0:
                _spritesPackSelected = _spritesPack1;
                break;
            case 1:
                _spritesPackSelected = _spritesPack2;
                break;
            case 2:
                _spritesPackSelected = _spritesPack3;
                break;
            case 3:
                _spritesPackSelected = _spritesPack4;
                break;
        }

        if (_cards.Length != _spritesPackSelected.Length *2 )
        {
            Debug.LogError("Need more sprites. Must be card = sprites * 2");
            return;
        }

        List<Sprite> cardList = new List<Sprite>();

        foreach (Sprite sprite in _spritesPackSelected)
        {
            cardList.Add(sprite);
            cardList.Add(sprite);
        }

        Mix(cardList);

        for (int i = 0; i < cardList.Count; i++)
        {
            _cards[i].sprite = cardList[i];
        }
    }

    private void Mix(List<Sprite> cardList)
    {
        for(int i = 0; i < cardList.Count; i++)
        {
            Sprite temp = cardList[i];
            int randomIndex = Random.Range(i, cardList.Count);
            cardList[i] = cardList[randomIndex];
            cardList[randomIndex] = temp;
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
