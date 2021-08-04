using System;
using Mortis.Bancho.Serializer;

namespace Mortis.Bancho.Bancho.Packets {
    public class Packet {
        public RequestType RequestType;
        public byte[]      PacketData;

        public Packet() {}
        public Packet(RequestType type, Serializable packetData) {
            this.RequestType = type;
            this.PacketData = packetData.ToBytes();
        }

        public static implicit operator Packet(Serializable serializable) {
            PacketType packetType = (PacketType) Attribute.GetCustomAttribute(serializable.GetType(), typeof(PacketType));

            if (packetType == null)
                throw new Exception("Attempted to implicitly convert Packet without the PacketType Attribute.");

            return new Packet(packetType.RequestType, serializable);
        }

        public SerializablePacket ToSerializable() => new() {
            RequestType  = this.RequestType,
            Compressed   = false,
            PacketLength = this.PacketData.Length,
            PacketData   = this.PacketData
        };
    }

    public class SerializablePacket : Serializable {
        [BanchoSerialize] public RequestType RequestType;
        [BanchoSerialize] public bool        Compressed = false;
        [BanchoSerialize] public int         PacketLength;
        [BanchoSerialize] public byte[]      PacketData;
    }
}
