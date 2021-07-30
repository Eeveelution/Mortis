using System.IO;
using EeveeTools.Helpers;
using Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables;
using NUnit.Framework;

namespace Mortis.Bancho.Serializer.Tests.SerializationTests {
    public class Tests {
        [SetUp]
        public void Setup() {}

        [Test]
        public void AttemptSerializeSimpleArray() {
            Stream testStream = new MemoryStream();

            using BanchoWriter writer = new(testStream);

            writer.Write("test1");
            writer.Write("test2");
            writer.Write("test3");

            ArraySerializable serializable = new();

            serializable.ReadFromStream(testStream);

            if(serializable.TestArray[0] == "test1" &&
               serializable.TestArray[1] == "test2" &&
               serializable.TestArray[2] == "test3")
            {
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [Test]
        public void AttemptSerializeSerializableArray() {
            Assert.Pass();
        }

        [Test]
        public void AttemptSerializeEnums() {
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
