namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables {
    public class Match : Serializable {
        [BanchoSerialize] public ushort MatchId;
        [BanchoSerialize] public bool   InProgress;
        [BanchoSerialize] public byte   UselessByte;
        [BanchoSerialize] public ushort Mods;
        [BanchoSerialize] public string GameName;
        [BanchoSerialize] public string Password;
        [BanchoSerialize] public string BeatmapChecksum;
        [BanchoSerialize] public int    BeatmapId;
        [BanchoSerialize] public string BeatmapText;
        [BanchoSerialize] public byte[] SlotStatuses = new byte[8];
        [BanchoSerialize] public byte[] SlotTeams    = new byte[8];
        [BanchoSerialize] public int[]  SlotIds      = new int[8];
        [BanchoSerialize] public int    HostUserId;
        [BanchoSerialize] public byte   GamePlaymode;
        [BanchoSerialize] public byte   MatchScoringType;
        [BanchoSerialize] public byte   MatchTeamType;
    }
}
