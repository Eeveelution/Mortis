namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables {
    public class EnumSerializable : Serializable {
    [BanchoSerialize] public TestEnum[] TestEnumArray = new TestEnum[4];
    }
}
