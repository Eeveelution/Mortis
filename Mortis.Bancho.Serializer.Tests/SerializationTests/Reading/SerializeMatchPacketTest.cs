using System.IO;
using EeveeTools.Helpers;
using Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables;
using NUnit.Framework;

namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Reading {
    public partial class Tests {
        [Test]
        public void ReadMatchPacket() {
            //Create Match packet from scratch
            Stream matchStream = new MemoryStream();

            using BanchoWriter writer = new(matchStream);

            writer.Write((ushort)123); //match id
            writer.Write(false); //in progress
            writer.Write((byte)0); //useless
            writer.Write((ushort)64); //mods
            writer.Write("epic game"); //game name
            writer.Write("epic password"); //passwprd
            writer.Write("insert checksum here"); //beatmap checksum
            writer.Write(123123123); //beatmap id
            writer.Write("dubstep - dubstep [dubstep]"); //beatmap text

            for(int i = 0; i != 16; i++)
                writer.Write((byte)2); //filling slot statuses&teams&slotids with 2

            for(int i = 0; i != 8; i++)
                writer.Write(2);

            writer.Write(234234234); //host user id
            writer.Write((byte)1); // playmode
            writer.Write((byte)2); // scoring type
            writer.Write((byte)3); //team type

            Match match = new();
            match.ReadFromStream(matchStream);

            //testing every single value, yes its messy but im too lazy to make it look clean
            if(match.MatchId != 123)
                Assert.Fail();
            if(match.InProgress)
                Assert.Fail();
            if(match.UselessByte != 0)
                Assert.Fail();
            if(match.Mods != 64)
                Assert.Fail();
            if(match.GameName != "epic game")
                Assert.Fail();
            if(match.Password != "epic password")
                Assert.Fail();
            if(match.BeatmapChecksum != "insert checksum here")
                Assert.Fail();
            if(match.BeatmapId != 123123123)
                Assert.Fail();
            if(match.BeatmapText != "dubstep - dubstep [dubstep]")
                Assert.Fail();

            for(int i = 0; i != 8; i++) {
                if(match.SlotIds[i] != 2)
                    Assert.Fail();
                if(match.SlotStatuses[i] != 2)
                    Assert.Fail();
                if(match.SlotTeams[i] != 2)
                    Assert.Fail();
            }

            Assert.Pass();
        }
    }
}
