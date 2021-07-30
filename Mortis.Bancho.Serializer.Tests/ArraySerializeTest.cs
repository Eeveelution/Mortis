using System.IO;
using EeveeTools.Helpers;
using NUnit.Framework;

namespace Mortis.Bancho.Serializer.Tests {
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

        }
    }
}
