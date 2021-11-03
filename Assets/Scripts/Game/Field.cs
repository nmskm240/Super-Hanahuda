using UnityEngine;

namespace SuperHanahuda.Game
{
    public class Field : MonoBehaviour
    {
        public void PutCard(GameObject card)
        {
            card.transform.SetParent(transform);
            card.GetComponent<CardController>().OnPlay.Invoke();
        }
    }
}