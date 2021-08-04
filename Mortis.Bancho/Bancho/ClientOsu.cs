using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using Mortis.Bancho.Bancho.Packets;

namespace Mortis.Bancho.Bancho.Objects {
    public class ClientOsu {
        private BlockingCollection<Packet> _packetQueue = new();

        public ClientOsu(HttpListenerContext ctx) {
            string[] loginData = new StreamReader(ctx.Request.InputStream).ReadToEnd().Split("\n");

            try {
                string username = loginData[0];
                string password = loginData[1];
                string clientData = loginData[2];
            }
            catch (Exception e) {

            }
        }

        public void QueuePacket(Packet packet) => this._packetQueue.Add(packet);
    }
}
