using System.Linq;
using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Game;

namespace SuperHanahuda.Network.CustomProperties
{
    public static class PlayerProperties
    {
        public static readonly string HandPropKey = "hand";

        private static readonly Hashtable _hashtable = new Hashtable();

        public static void SetHand(this Player player, IEnumerable<CardModel> cards)
        {
            _hashtable[HandPropKey] = cards.ToArray();
        }

        public static List<CardModel> GetHand(this Player player)
        {
            return new List<CardModel>(player.CustomProperties[HandPropKey] as IEnumerable<CardModel>);
        }

        public static void SetPlayerProperties(this Player player)
        {
            if (_hashtable.Count > 0)
            {
                player.SetCustomProperties(_hashtable);
                _hashtable.Clear();
            }
        }
    } 
}