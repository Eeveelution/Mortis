using System;
using System.Runtime.CompilerServices;

namespace Mortis.Bancho.Serializer {
    /// <summary>
    /// Used to find Fields to Serialize and to order said fields
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class BanchoSerialize : Attribute {
        public int Order;

        public BanchoSerialize([CallerLineNumber] int order = 0) => this.Order = order;
    }
}
