namespace Mortis.Bancho.Serializer.Tests.SerializationTests.Serializables {
    public class SerializableArraySerializable : Serializable {
        [BanchoSerialize] public ArraySerializable[] Serializable = new ArraySerializable[3];
    }
}
