namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables {
    public class IntSerializable : Serializable {
        [BanchoSerialize] public int[] TestInt = new int[8];
    }
}
