using System.IO;
using EeveeTools.Helpers;
using Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables;
using NUnit.Framework;

namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Reading {
    public partial class Tests {
        [Test]
        public void ReadSerializableArray() {
            Stream testStream = new MemoryStream();

            using BanchoWriter writer = new(testStream);

            writer.Write("test1");
            writer.Write("test2");
            writer.Write("test3");
            writer.Write("test1");
            writer.Write("test2");
            writer.Write("test3");
            writer.Write("test1");
            writer.Write("test2");
            writer.Write("test3");

            SerializableArraySerializable whatTheFuck = new();
            whatTheFuck.ReadFromStream(testStream);

            for (int i = 0; i != 3; i++) {
                ArraySerializable serializable = whatTheFuck.Serializable[i];

                if(serializable.TestArray[0] != "test1" &&
                   serializable.TestArray[1] != "test2" &&
                   serializable.TestArray[2] != "test3")
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }
    }
}
