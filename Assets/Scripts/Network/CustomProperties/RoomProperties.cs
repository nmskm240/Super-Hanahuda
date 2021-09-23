using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Game;

namespace SuperHanahuda.Network.CustomProperty
{
    public static class RoomProperties
    {
        private static readonly string _deck = "deck"; 

        private static readonly Hashtable _hashtable = new Hashtable();

        public static void SetDeck(this Room room, IEnumerable<CardModel> cards)
        {
            _hashtable[_deck] = cards;
        }

        public static List<CardModel> GetDeck(this Room room)
        {
            return room.CustomProperties[_deck] is IEnumerable<CardModel> cards ? new List<CardModel>(cards) : new List<CardModel>();
        }
    }
}