using UnityEngine;
using SuperHanahuda.Game;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Deck _deck;
    [SerializeField]
    private Transform _enemyHand;
    [SerializeField]
    private Transform _field;
    [SerializeField]
    private Transform _playerHand;

    private void Awake()
    {
        _deck.Shuffle();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                var card = _deck.Draw();
                card.transform.SetParent(_playerHand);
                card.transform.localScale = Vector3.one * 1.2f;
                card.GetComponent<CardController>().View.ToggleFace();
            }
            for (int j = 0; j < 2; j++)
            {
                var card = _deck.Draw();
                card.transform.SetParent(_field);
                card.transform.localScale = Vector3.one;
                card.GetComponent<CardController>().View.ToggleFace();
            }
            for (int j = 0; j < 2; j++)
            {
                var card = _deck.Draw();
                card.transform.SetParent(_enemyHand);
                card.transform.localScale = Vector3.one * 1.2f;
            }
        }
    }
}