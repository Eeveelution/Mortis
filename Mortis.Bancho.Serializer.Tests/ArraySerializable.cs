namespace Mortis.Bancho.Serializer.Tests {
    public class ArraySerializable : Serializable {
        [BanchoSerialize] public string[] TestArray = new string[3];
    }
}
