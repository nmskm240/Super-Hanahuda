using System.Linq;
using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Game;

namespace SuperHanahuda.Network.CustomProperty
{
    public static class RoomProperties
    {
        public static readonly string DeckPropKey = "deck";

        private static readonly Hashtable _hashtable = new Hashtable();

        public static void SetDeck(this Room room, Deck deck)
        {
            _hashtable[DeckPropKey] = deck.Cards.ToArray();
        }

        public static Deck GetDeck(this Room room)
        {
            var cards = room.CustomProperties[DeckPropKey] as IEnumerable<CardModel>;
            return new Deck(cards);
        }

        public static void SetRoomProperties(this Room room)
        {
            if (_hashtable.Count > 0)
            {
                room.SetCustomProperties(_hashtable);
                _hashtable.Clear();
            }
        }
    }
}