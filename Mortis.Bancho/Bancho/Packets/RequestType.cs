using System;

namespace Mortis.Bancho.Bancho.Packets {
    public enum RequestType : short {
        BanchoLoginReply = 5
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class PacketType : Attribute {
        public RequestType RequestType { get; }

        public PacketType(RequestType type) => this.RequestType = type;
    }
}
