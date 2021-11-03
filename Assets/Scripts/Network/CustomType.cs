using UnityEngine;
using ExitGames.Client.Photon;
using SuperHanahuda.Game;

namespace SuperHanahuda.Network
{
    public static class CustomType
    {
        private static readonly byte[] _bufferCardModel = new byte[sizeof(int)];

        public static void Register()
        {
            PhotonPeer.RegisterType(typeof(CardModel), (byte)'C', SerializeCardModel, DeserializeCardModel);
        }

        private static short SerializeCardModel(StreamBuffer outStream, object obj)
        {
            var model = obj as CardModel;
            var index = 0;
            lock(_bufferCardModel)
            {
                Protocol.Serialize(model.ID, _bufferCardModel, ref index);
                outStream.Write(_bufferCardModel, 0, index);
            }
            return (short)index;
        }

        private static object DeserializeCardModel(StreamBuffer inStream, short length)
        {
            int id;
            var index = 0;
            lock(_bufferCardModel)
            {
                inStream.Read(_bufferCardModel, 0, length);
                Protocol.Deserialize(out id, _bufferCardModel, ref index);
            }
            return Resources.Load($"Datas/Cards/{ id }");
        }
    }
}