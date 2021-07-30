using System;
using System.Runtime.CompilerServices;

namespace Mortis.Bancho.Serializer {
    public sealed class BanchoSerialize : Attribute {
        public int Order;

        public BanchoSerialize([CallerLineNumber] int order = 0) => this.Order = order;
    }
}
