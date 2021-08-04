using Mortis.Bancho.Serializer;

namespace Mortis.Bancho.Bancho.Packets {
    [PacketType(RequestType.BanchoLoginReply)]
    public class BanchoLoginReply : Serializable {
        [BanchoSerialize] public int UserId;
    }
}
