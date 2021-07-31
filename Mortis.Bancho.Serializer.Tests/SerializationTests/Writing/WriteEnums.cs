using System.IO;
using Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables;
using Mortis.Bancho.Serializer.Tests.SerializationTests.TestTypes;
using NUnit.Framework;

namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Writing {
    public partial class Tests {
        [Test]
        public void WriteEnums() {
            EnumSerializable serializable = new() {
                TestEnumArray = new TestEnum[] {
                    TestEnum.Value1,
                    TestEnum.Value3,
                    TestEnum.Value3,
                    TestEnum.Value3
                }
            };

            Stream stream = new MemoryStream();
            serializable.WriteToStream(stream);

            EnumSerializable readSerializable = new();
            readSerializable.ReadFromStream(stream);

            if (readSerializable.TestEnumArray[0] == TestEnum.Value1 &&
                readSerializable.TestEnumArray[1] == TestEnum.Value3 &&
                readSerializable.TestEnumArray[2] == TestEnum.Value3 &&
                readSerializable.TestEnumArray[3] == TestEnum.Value3)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

    }
}
