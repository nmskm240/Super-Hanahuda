using System.Linq;
using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Game;

namespace SuperHanahuda.Network.CustomProperties
{
    public static class RoomProperties
    {
        public static readonly string DECK_KEY = "deck";
        public static readonly string PARENT_PLAYER_KEY = "parent";

        private static readonly Hashtable _hashtable = new Hashtable();

        public static void SetDeck(this Room room, Deck deck)
        {
            _hashtable[DECK_KEY] = deck.Cards.ToArray();
        }

        public static Deck GetDeck(this Room room)
        {
            var cards = room.CustomProperties[DECK_KEY] as IEnumerable<CardModel>;
            return new Deck(cards);
        }

        public static void SetParentPlayer(this Room room, Player parent)
        {
            _hashtable[PARENT_PLAYER_KEY] = parent;
        }

        public static Player GetParentPlayer(this Room room)
        {
            return room.CustomProperties[PARENT_PLAYER_KEY] as Player;
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