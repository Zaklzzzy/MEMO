using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardChecker : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _menuButton;
    [Header("Count")]
    [SerializeField] private int _cardCount;
    private int _counter;
    public GameObject _firstSelectedCard;
    public GameObject _secondSelectedCard;

    private void Update()
    {
        if (_cardCount == _counter)
        {
            _menuButton.SetActive(false);
            _winText.SetActive(true);
            Invoke("Win", 1.25f);
        }
    }

    public void CardSelected(GameObject selectedCard)
    {
        if (_firstSelectedCard == null)
        {
            _firstSelectedCard = selectedCard;
            ToggleCard(_firstSelectedCard, true);
            Debug.Log("_firstSelectedCard = " + _firstSelectedCard.GetComponent<Card>()._childImage.sprite);
        }
        else if (_secondSelectedCard == null && selectedCard != _firstSelectedCard)
        {
            _secondSelectedCard = selectedCard;
            ToggleCard(_secondSelectedCard, true);
            Debug.Log("_secondSelectedCard = " + _secondSelectedCard.GetComponent<Card>()._childImage.sprite);
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if(_firstSelectedCard && _secondSelectedCard)
        {
            if (_firstSelectedCard.GetComponent<Card>()._childImage.sprite == _secondSelectedCard.GetComponent<Card>()._childImage.sprite)
            {
                _firstSelectedCard.GetComponent<Button>().enabled = false;
                _secondSelectedCard.GetComponent<Button>().enabled = false;
                _counter++;
            }
            else
            {
                yield return new WaitForSeconds(1.2f);

                ToggleCard(_firstSelectedCard, false);
                ToggleCard(_secondSelectedCard, false);
            }
        }
        else
        {
            Debug.LogError("Card not Selected");
        }

        _firstSelectedCard = null;
        _secondSelectedCard = null;
    }

    private void ToggleCard(GameObject card, bool show)
    {
        card.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = show;
        card.GetComponent<Image>().enabled = !show;
    }

    private void Win()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
