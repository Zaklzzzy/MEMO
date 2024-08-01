using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image[] _cards;

    private int[] _spritesUsed;

    private void Start()
    {
        InitializeCards();
    }

    private void InitializeCards()
    {
        if(_cards.Length != _sprites.Length *2 )
        {
            Debug.LogError("Need more sprites. Must be card = sprites * 2");
            return;
        }

        List<Sprite> cardList = new List<Sprite>();

        foreach (Sprite sprite in _sprites)
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
}
