using System.Net;
using Mortis.Bancho.Serializer;

namespace Mortis.Bancho.Bancho.Helpers {
    public static class ResponseHelpers {
        public static void WritePacket(this HttpListenerResponse res, Serializable serializable) {
            serializable.WriteToStream(res.OutputStream);
        }
    }
}
