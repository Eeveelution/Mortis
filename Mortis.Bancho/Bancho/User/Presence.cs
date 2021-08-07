using Mortis.Bancho.Serializer;
using Mortis.Common.Objects;

namespace Mortis.Bancho.Bancho {
    public class Presence : Serializable {
        [BanchoSerialize] public int    UserId;
        [BanchoSerialize] public string Username;
        [BanchoSerialize] public byte   Timezone;
        [BanchoSerialize] public byte   CountryCode;
        [BanchoSerialize] public byte   PermissionsAndMode;
        [BanchoSerialize] public float  Longnitude;
        [BanchoSerialize] public float  Latitude;
        [BanchoSerialize] public int    Rank;

        private UserStats StandardStats;
        private UserStats TaikoStats;
        private UserStats CatchStats;
        private UserStats ManiaStats;

        private PlayModes CurrentMode = PlayModes.Osu;

        public void SetPermissionsAndMode(Permissions perms, PlayModes mode) {
            //Blame peppy...
            this.PermissionsAndMode = (byte) (((byte) perms & 0x1f) | (((byte) mode & 0x7) << 5));
        }

        public static Presence FromUser(User user) {
            return new() {
                UserId      = (int) user.UserId,
                Username    = user.Username,
                CountryCode = 0,
                Latitude    = 0,
                Longnitude  = 0,
                Rank        = (int)user.StandardStats.PerformanceRank,
                StandardStats = user.StandardStats,
                TaikoStats = user.TaikoStats,
                CatchStats = user.CatchStats,
                ManiaStats = user.ManiaStats
            };
        }
    }
}
