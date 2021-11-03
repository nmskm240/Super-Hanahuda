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
        private static readonly Hashtable _hashtable = new Hashtable();

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