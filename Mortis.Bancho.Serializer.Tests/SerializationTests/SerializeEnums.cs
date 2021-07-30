using System.IO;
using EeveeTools.Helpers;
using Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables;
using NUnit.Framework;

namespace Mortis.Bancho.Serializer.Tests.SerializationTests {
    public partial class Tests {
        [Test]
        public void SerializeEnums() {
            Stream testStream = new MemoryStream();
            using BanchoWriter writer = new (testStream);

            writer.Write((byte)0);
            writer.Write((byte)1);
            writer.Write((byte)2);
            writer.Write((byte)2);

            EnumSerializable serializable = new();
            serializable.ReadFromStream(testStream);

            if(serializable.TestEnumArray[0] == TestEnum.Value1 && serializable.TestEnumArray[1] == TestEnum.Value2 && serializable.TestEnumArray[2] == TestEnum.Value3 && serializable.TestEnumArray[3] == TestEnum.Value3)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
