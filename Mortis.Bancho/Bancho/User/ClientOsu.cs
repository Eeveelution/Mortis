using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using Mortis.Bancho.Bancho.Helpers;
using Mortis.Bancho.Bancho.Packets;
using Mortis.Bancho.Bancho.Packets.User;
using Mortis.Common.Objects;

namespace Mortis.Bancho.Bancho {
    public class ClientOsu {
        private BlockingCollection<Packet> _packetQueue = new();

        private User UserData;

        //private Presence

        public ClientOsu(HttpListenerContext ctx) {
            string[] loginData = new StreamReader(ctx.Request.InputStream).ReadToEnd().Split("\n");

            try {
                string username = loginData[0];
                string password = loginData[1];
                string clientData = loginData[2];

                User foundUser = User.FromDatabase(Global.DatabaseContext, username);

                if (foundUser == null) {
                    //Create new User
                    foundUser = User.CreateUser(Global.DatabaseContext, username, "", password);
                } else {
                    bool correctPassword = BCrypt.Net.BCrypt.Verify(password, foundUser.PasswordBcrypt, true);

                    if (!correctPassword) {
                        ctx.Response.WritePacket(new BanchoLoginReply(LoginResponse.WrongLogin));
                        ctx.Response.Close();
                    }
                }


            }
            catch (Exception e) {
                ctx.Response.WritePacket(new BanchoLoginReply(LoginResponse.ServerError));
                ctx.Response.Close();
            }
        }

        public void QueuePacket(Packet packet) => this._packetQueue.Add(packet);
    }
}
