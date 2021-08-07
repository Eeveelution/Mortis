using System.IO;
using Mortis.Bancho;
using Mortis.Bancho.Bancho;
using Mortis.Bancho.Bancho.Packets;
using Mortis.Bancho.Bancho.Packets.User;
using Mortis.Common.Objects;

MemoryStream testOutputStream = new ();

Packet reply = new BanchoLoginReply(5);

reply.ToSerializable().WriteToStream(testOutputStream);

byte[] debugOut = testOutputStream.ToArray();


new BanchoServer("http://127.0.0.1:13382/").Start().BlockThread();