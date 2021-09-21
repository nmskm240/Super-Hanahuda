using UnityEngine;

namespace SuperHanahuda.Game
{
    public class Field : MonoBehaviour
    {
        public void PutCard(GameObject card)
        {
            card.transform.SetParent(transform);
            card.transform.localScale = Vector3.one;
            card.GetComponent<CardController>().OnPlay.Invoke();
        }
    }
}