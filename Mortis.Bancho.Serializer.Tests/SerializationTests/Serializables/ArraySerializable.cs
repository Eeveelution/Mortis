namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables {
    public class ArraySerializable : Serializable {
        [BanchoSerialize] public string[] TestArray = new string[3];
    }
}
