using Mortis.Bancho.Serializer;

namespace Mortis.Bancho.Bancho.Packets.User {
    public enum LoginResponse : int {
        WrongLogin = -1,
        OldClient = -2,
        Banned = -3,
        Banned2 = -4,
        ServerError = -5,
        SupporterRequired = -6,
        PasswordReset = -7,
        VerificationRequied = -8,
    }

    [PacketType(RequestType.BanchoLoginReply)]
    public class BanchoLoginReply : Serializable {
        public BanchoLoginReply(int userId) => this.UserId = userId;
        public BanchoLoginReply(LoginResponse response) => this.UserId = (int) response;

        [BanchoSerialize] public int    UserId;
        public                   string shit = "sdf";
    }
}
