namespace Mortis.Bancho.Serializer.Tests {
    public class IntSerializable : Serializable {
        [BanchoSerialize] public int[] TestInt = new int[8];
    }
}
